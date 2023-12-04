using AutoMapper;
using TestProject.Entities;
using TestProject.Models;

namespace TestProject.MappingProfile
{
    public class GroceriesMappingProfile : Profile
    {
        public GroceriesMappingProfile()
        {
            CreateMap<GroceryListEntry, GroceryListEntryDTO>();
            CreateMap<GroceryListEntryDTO, GroceryListEntry>();
            CreateMap<GroceryList, GroceryListDTO>();
            CreateMap<GroceryListDTO, GroceryList>();
        }
    }
}
