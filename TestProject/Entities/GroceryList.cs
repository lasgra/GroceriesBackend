using System.ComponentModel.DataAnnotations;

namespace TestProject.Entities
{
    public class GroceryList
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public virtual IList<GroceryListEntry> GroceryEntries { get; set; }
    }
}
