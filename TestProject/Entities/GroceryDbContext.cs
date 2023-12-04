using Microsoft.EntityFrameworkCore;
using TestProject.Services;

namespace TestProject.Entities
{
    public class GroceryDbContext : DbContext
    {
        private string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=GroceryListDb;Trusted_Connection=True";
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<GroceryListEntry>  GroceryListEntries { get; set; }
        public DbSet<GroceryList> GroceryList { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroceryListEntry>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(40);

            modelBuilder.Entity<User>()
                .Property(r => r.Email)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
            new GrocerySeeder(modelBuilder).Seed();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
