using System.ComponentModel.DataAnnotations;
using TestProject.Entities;

namespace TestProject.Models
{
    public class GroceryListDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public IList<GroceryListEntryDTO> GroceryEntries { get; set; }
    }
}
