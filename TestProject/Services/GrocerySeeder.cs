using Microsoft.EntityFrameworkCore;
using TestProject.Entities;

namespace TestProject.Services
{
    public class GrocerySeeder
    {
        private readonly ModelBuilder modelBuilder;
        public GrocerySeeder(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }
        public void Seed()
        {
            modelBuilder.Entity<Role>().HasData(
                new Role() { Id = 1, Name = "User" },
                new Role() { Id = 2, Name = "Admin" }
            );

            modelBuilder.Entity<GroceryListEntry>().HasData(
                new GroceryListEntry(){Id = 1,Name = "Apple",   Category = "Fruit",     Unit = "kg",Price = 3.49M},
                new GroceryListEntry(){Id = 2,Name = "Banana",  Category = "Fruit",     Unit = "kg",Price = 6.99M},
                new GroceryListEntry(){Id = 3,Name = "Peach",   Category = "Fruit",     Unit = "kg",Price = 7.01M},
                new GroceryListEntry(){Id = 4,Name = "Grape",   Category = "Fruit",     Unit = "kg",Price = 10.00M},
                new GroceryListEntry(){Id = 5,Name = "Plum",  Category = "Fruit",     Unit = "kg",Price = 6.49M},
                new GroceryListEntry(){Id = 6,Name = "Pineapple",   Category = "Fruit",     Unit = "kg",Price = 8.00M},
                new GroceryListEntry(){Id = 7,Name = "Tomato",  Category = "Vegetable", Unit = "kg",Price = 12.49M},
                new GroceryListEntry(){Id = 8,Name = "Carrot",  Category = "Vegetable", Unit = "kg",Price = 2.99M},
                new GroceryListEntry(){Id = 9,Name = "Potato",  Category = "Vegetable", Unit = "kg",Price = 2.99M},
                new GroceryListEntry(){Id = 10,Name = "Onion",  Category = "Vegetable", Unit = "kg",Price = 3.49M},
                new GroceryListEntry(){Id = 11,Name = "Cabbage",  Category = "Vegetable", Unit = "kg",Price = 3.79M},
                new GroceryListEntry(){Id = 13,Name = "Milk",    Category = "Drink",     Unit = "Pcs",Price = 2.49M},
                new GroceryListEntry(){Id = 14,Name = "Sprite",  Category = "Drink",     Unit = "Pcs",Price = 6.50M},
                new GroceryListEntry(){Id = 15,Name = "Coca Cola",    Category = "Drink",     Unit = "Pcs",Price = 5.99M},
                new GroceryListEntry(){Id = 16,Name = "Tymbark",  Category = "Drink",     Unit = "Pcs",Price = 4.99M},
                new GroceryListEntry(){Id = 17,Name = "Skittles",Category = "Candy",     Unit = "Pcs",Price = 9.99M},
                new GroceryListEntry(){Id = 18,Name = "Chocolate",Category = "Candy",    Unit = "Pcs",Price = 4.69M},
                new GroceryListEntry(){Id = 19,Name = "Lay's",Category = "Candy",     Unit = "Pcs",Price = 11.39M },
                new GroceryListEntry(){Id = 20,Name = "M&M's", Category = "Candy",     Unit = "Pcs",Price = 8.65M }
            );
        }
    }
}
