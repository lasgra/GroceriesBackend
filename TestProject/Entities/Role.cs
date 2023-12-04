using System.ComponentModel.DataAnnotations;

namespace TestProject.Entities
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
