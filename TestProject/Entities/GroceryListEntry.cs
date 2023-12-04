using System.ComponentModel.DataAnnotations;

namespace TestProject.Entities
{
    public class GroceryListEntry
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int? Amount { get; set; } = null;
        public string Unit { get; set; }
        public decimal Price { get; set; }
        public int? GroceryListId { get; set; } = null;
    }
}
