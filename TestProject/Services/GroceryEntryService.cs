using AutoMapper;
using System.Linq.Expressions;
using TestProject.Entities;
using TestProject.Exceptions;
using TestProject.Models;

namespace TestProject.Services
{
    public interface IGroceryEntryService
    {
        IEnumerable<GroceryListEntryDTO> GetAll(GroceryQuery query);
        GroceryListEntryDTO GetById(int Id);
        void CreateGroceryEntry(GroceryListEntry Grocery);
        void DeleteGrocery(int Id);
        void PutGrocery(decimal Price, int Id);
    }

    public class GroceryEntryService : IGroceryEntryService
    {
        private readonly GroceryDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GroceryEntryService> _logger;
        public GroceryEntryService(GroceryDbContext context, IMapper mapper, ILogger<GroceryEntryService> logger)
        {
            _context  = context;
            _mapper = mapper;
            _logger = logger;
        }
        public IEnumerable<GroceryListEntryDTO> GetAll(GroceryQuery query)
        {
            _logger.LogError($"GroceryEntry GET all action invoked");

            var Groceries = _context.GroceryListEntries.Where(x => x.GroceryListId == null).ToList();
            var GroceriesDTO = _mapper.Map<List<GroceryListEntryDTO>>(Groceries);
            var sortedList = GroceriesDTO;

            if (!string.IsNullOrEmpty(query.SortBy))
            {
                var columnsSelectors = new Dictionary<string, Expression<Func<GroceryListEntryDTO, object>>>
                {
                    { nameof(GroceryListEntryDTO.Name), x => x.Name },
                    { nameof(GroceryListEntryDTO.Id), x => x.Id },
                    { nameof(GroceryListEntryDTO.Price), x => x.Price },
                };

                var selectedColumn = columnsSelectors[query.SortBy];

                sortedList = (query.SortDirection == SortDirection.ASC
                    ? GroceriesDTO.OrderBy(entry => selectedColumn.Compile()(entry)).ToList()
                    : GroceriesDTO.OrderByDescending(entry => selectedColumn.Compile()(entry)).ToList());

            };

            return sortedList;
        }
        public GroceryListEntryDTO GetById(int Id)
        {
            _logger.LogError($"GroceryEntry with id: {Id} GET action invoked");

            var Entry = _context.GroceryListEntries.FirstOrDefault(x => x.Id == Id);
            if (Entry is null)
                throw new NotFoundException("GroceryEntry not found");

            var MappedEntry = _mapper.Map<GroceryListEntryDTO>(Entry);
            return MappedEntry;
        }
        public void CreateGroceryEntry(GroceryListEntry Grocery)
        {
            _logger.LogError($"GroceryEntry with id: {Grocery.Id} POST action invoked");

            _context.GroceryListEntries.Add(Grocery);
            _context.SaveChanges();
        }
        public void DeleteGrocery(int Id)
        {
            _logger.LogError($"GroceryEntry with id: {Id} DELETE action invoked");

            var Entry = _context.GroceryListEntries.FirstOrDefault(x => x.Id == Id);
            if (Entry is null)
                throw new NotFoundException("GroceryEntry not found");

            _context.GroceryListEntries.Remove(Entry);
            _context.SaveChanges();
        } 
        public void PutGrocery(decimal Price, int Id)
        {
            _logger.LogError($"GroceryEntry with id: {Id} PUT action invoked");

            var Entry = _context.GroceryListEntries.FirstOrDefault(x => x.Id == Id);
            if (Entry is null)
                throw new NotFoundException("GroceryEntry not found");

            Entry.Price = Price;
            _context.SaveChanges();
        }
    }
}
