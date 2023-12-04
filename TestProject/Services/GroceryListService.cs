using AutoMapper;
using TestProject.Entities;
using TestProject.Models;
using TestProject.Exceptions;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using TestProject.Authorization;
using System.Linq.Expressions;

namespace TestProject.Services
{
    public interface IGroceryListService
    {
        List<GroceryListDTO> GetLists(int Id, GroceryQuery query);
        GroceryListDTO GetList(int Id, GroceryQuery query);
        string PostList(GroceryListDTO dto, int UserId);
        string AddEntry(int ListId, GroceryListEntryDTO dto);
        string DeleteList(int ListId, ClaimsPrincipal user);
        string DeleteEntry(int ListId, string EntryName, ClaimsPrincipal user);
        string EditList(int ListId, EditGroceryDTO query);

    }
    public class GroceryListService : IGroceryListService
    {
        private readonly GroceryDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GroceryEntryService> _logger;
        private readonly IAuthorizationService _authorizationService;
        public GroceryListService(GroceryDbContext context, IMapper mapper, ILogger<GroceryEntryService> logger, IAuthorizationService authorizationService)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _authorizationService = authorizationService;
        }
        public List<GroceryListDTO> GetLists(int Id, GroceryQuery query)
        {
            _logger.LogError($"GroceryList GET lists action invoked");

            List<GroceryList> List = _context.GroceryList.Where(x => x.UserId == Id).ToList();
            if (List == null) throw new NotFoundException("Grocerylists not found");

            List<GroceryListDTO> dtos = _mapper.Map<List<GroceryListDTO>>(List);
            foreach (var dto in dtos)
            {
                var sorted = _mapper.Map<List<GroceryListEntryDTO>>(_context.GroceryListEntries.Where(x => x.GroceryListId == dto.Id));
                dto.GroceryEntries = sorted;
                if (!string.IsNullOrEmpty(query.SortBy))
                {
                    var columnsSelectors = new Dictionary<string, Expression<Func<GroceryListEntryDTO, object>>>
                    {
                        { nameof(GroceryListEntryDTO.Name), x => x.Name },
                        { nameof(GroceryListEntryDTO.Id), x => x.Id },
                        { nameof(GroceryListEntryDTO.Price), x => x.Price },
                    };
    
                    var selectedColumn = columnsSelectors[query.SortBy];

                    sorted = (query.SortDirection == SortDirection.ASC
                        ? dto.GroceryEntries.OrderBy(entry => selectedColumn.Compile()(entry)).ToList()
                        : dto.GroceryEntries.OrderByDescending(entry => selectedColumn.Compile()(entry)).ToList());
                };
                dto.GroceryEntries = sorted;
            }

            return dtos;
        }
        public GroceryListDTO GetList(int Id, GroceryQuery query)
        {
            _logger.LogError($"GroceryList GET list action invoked");

            GroceryList list = _context.GroceryList.FirstOrDefault(x => x.Id == Id);
            if(list == null) throw new NotFoundException("Grocerylist not found");

            GroceryListDTO dto = _mapper.Map<GroceryListDTO>(list);

            List<GroceryListEntry> entries = _context.GroceryListEntries.Where(x => x.GroceryListId == Id).ToList();
            if (entries == null) return dto;

            List<GroceryListEntryDTO> entriesDto = _mapper.Map<List<GroceryListEntryDTO>>(entries);
            dto.GroceryEntries = entriesDto;

            var sorted = _mapper.Map<List<GroceryListEntryDTO>>(_context.GroceryListEntries.Where(x => x.GroceryListId == dto.Id));
            dto.GroceryEntries = sorted;
            
            foreach (var item in dto.GroceryEntries)
            {
                item.Id = _context.GroceryListEntries.FirstOrDefault(x => x.Name == item.Name && x.GroceryListId == null)!.Id;
            }

            if (!string.IsNullOrEmpty(query.SortBy))
            {
                var columnsSelectors = new Dictionary<string, Expression<Func<GroceryListEntryDTO, object>>>
                    {
                        { nameof(GroceryListEntryDTO.Name), x => x.Name },
                        { nameof(GroceryListEntryDTO.Id), x => x.Id },
                        { nameof(GroceryListEntryDTO.Price), x => x.Price },
                    };

                var selectedColumn = columnsSelectors[query.SortBy];

                sorted = (query.SortDirection == SortDirection.ASC
                    ? dto.GroceryEntries.OrderBy(entry => selectedColumn.Compile()(entry)).ToList()
                    : dto.GroceryEntries.OrderByDescending(entry => selectedColumn.Compile()(entry)).ToList());
            };

            dto.GroceryEntries = sorted;

            return dto;
        }
        public string PostList(GroceryListDTO dto, int UserId)
        {
            _logger.LogError($"GroceryList with id: {dto.Id} POST action invoked");

            dto.UserId = UserId;
            GroceryList GroceryEntity = _mapper.Map<GroceryList>(dto);

            _context.GroceryList.Add(GroceryEntity);
            _context.SaveChanges();

            return _context.GroceryList.FirstOrDefault(x => x == GroceryEntity)!.Id.ToString();
        }
        public string AddEntry(int ListId, GroceryListEntryDTO dto)
        {
            _logger.LogError($"GroceryListEntry with id: {dto.Id} POST action invoked");

            GroceryList list = _context.GroceryList.FirstOrDefault(x => x.Id == ListId)!;
            if (list == null) throw new NotFoundException("Grocerylist not found");

            GroceryListEntry entry = _mapper.Map<GroceryListEntry>(dto);
            entry.GroceryListId = ListId;

            _context.GroceryListEntries.Add(entry);
            _context.SaveChanges();

            return "Entry added";
        }
        public string DeleteEntry(int ListId, string EntryName, ClaimsPrincipal user)
        {
            _logger.LogError($"GroceryListEntry with name: {EntryName} DELETE action invoked");

            GroceryList list = _context.GroceryList.FirstOrDefault(x => x.Id == ListId)!;
            if (list == null) throw new NotFoundException("Grocerylist not found");
            
            GroceryListEntry entry = _context.GroceryListEntries.FirstOrDefault(x => x.GroceryListId == ListId && x.Name == EntryName)!;
            if (entry == null) throw new NotFoundException("GroceryEntry not found");
            
            var authorization = _authorizationService.AuthorizeAsync(user, list, new ResourceOperationRequirement(ResourceOperation.Delete)).Result;
            if (!authorization.Succeeded) throw new ForbidException("JWTKey not specified");
            
            _context.GroceryListEntries.Remove(entry);
            _context.SaveChanges();

            return "Product " + entry.Name + ", was deleted";
        }
        public string DeleteList(int ListId, ClaimsPrincipal user)
        {
            _logger.LogError($"GroceryList with id: {ListId} DELETE action invoked");

            GroceryList list = _context.GroceryList.FirstOrDefault(x => x.Id == ListId)!;
            if (list == null) throw new NotFoundException("Grocerylist not found");

            var authorization = _authorizationService.AuthorizeAsync(user, list, new ResourceOperationRequirement(ResourceOperation.Delete)).Result;
            if (!authorization.Succeeded) throw new ForbidException("JWTKey not specified");
            
            List<GroceryListEntry> Entries = _context.GroceryListEntries.Where(x => x.GroceryListId == list.Id).ToList();
            foreach (var entry in Entries) _context.GroceryListEntries.Remove(entry);
            
            _context.GroceryList.Remove(list);
            _context.SaveChanges();
            
            return $"List with Id {ListId}, was deleted";
        }
        public string EditList(int ListId, EditGroceryDTO query)
        {
            GroceryList list = _context.GroceryList.FirstOrDefault(x => x.Id == ListId);
            if (list == null) throw new NotFoundException("Grocerylist not found");

            GroceryListEntry entry = _context.GroceryListEntries.FirstOrDefault(x => x.GroceryListId == list.Id  && x.Name == query.GroceryName);
            if (entry == null) throw new NotFoundException("GroceryEntry not found");
            
            _context.GroceryListEntries.FirstOrDefault(x => x.GroceryListId == list.Id && x.Name == query.GroceryName)!.Amount = entry.Amount + query.AmountChange;
            _context.SaveChanges();
            
            return "Entry amount has been changed";
        }
    }
}
