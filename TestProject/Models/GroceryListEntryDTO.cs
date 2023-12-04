using System.ComponentModel.DataAnnotations;

namespace TestProject.Models
{
    public class GroceryListEntryDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
        public string Category { get; set; }
        public int Amount { get; set; }
        public string Unit { get; set; }
        public decimal Price { get; set; }
    }
}
