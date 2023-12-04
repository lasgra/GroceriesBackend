using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestProject.Migrations
{
    /// <inheritdoc />
    public partial class final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "GroceryListEntries",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Category", "Name", "Price" },
                values: new object[] { "Fruit", "Grape", 10.00m });

            migrationBuilder.UpdateData(
                table: "GroceryListEntries",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Category", "Name", "Price" },
                values: new object[] { "Fruit", "Plum", 6.49m });

            migrationBuilder.UpdateData(
                table: "GroceryListEntries",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Category", "Name", "Price", "Unit" },
                values: new object[] { "Fruit", "Pineapple", 8.00m, "kg" });

            migrationBuilder.UpdateData(
                table: "GroceryListEntries",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Category", "Name", "Price", "Unit" },
                values: new object[] { "Vegetable", "Tomato", 12.49m, "kg" });

            migrationBuilder.UpdateData(
                table: "GroceryListEntries",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Category", "Name", "Price", "Unit" },
                values: new object[] { "Vegetable", "Carrot", 2.99m, "kg" });

            migrationBuilder.UpdateData(
                table: "GroceryListEntries",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Category", "Name", "Price", "Unit" },
                values: new object[] { "Vegetable", "Potato", 2.99m, "kg" });

            migrationBuilder.InsertData(
                table: "GroceryListEntries",
                columns: new[] { "Id", "Amount", "Category", "GroceryListId", "Name", "Price", "Unit" },
                values: new object[,]
                {
                    { 10, null, "Vegetable", null, "Onion", 3.49m, "kg" },
                    { 11, null, "Vegetable", null, "Cabbage", 3.79m, "kg" },
                    { 13, null, "Drink", null, "Milk", 2.49m, "Pcs" },
                    { 14, null, "Drink", null, "Sprite", 6.50m, "Pcs" },
                    { 15, null, "Drink", null, "Coca Cola", 5.99m, "Pcs" },
                    { 16, null, "Drink", null, "Tymbark", 4.99m, "Pcs" },
                    { 17, null, "Candy", null, "Skittles", 9.99m, "Pcs" },
                    { 18, null, "Candy", null, "Chocolate", 4.69m, "Pcs" },
                    { 19, null, "Candy", null, "Lay's", 11.39m, "Pcs" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GroceryListEntries",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "GroceryListEntries",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "GroceryListEntries",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "GroceryListEntries",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "GroceryListEntries",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "GroceryListEntries",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "GroceryListEntries",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "GroceryListEntries",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "GroceryListEntries",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.UpdateData(
                table: "GroceryListEntries",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Category", "Name", "Price" },
                values: new object[] { "Vegetable", "Tomato", 12.49m });

            migrationBuilder.UpdateData(
                table: "GroceryListEntries",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Category", "Name", "Price" },
                values: new object[] { "Vegetable", "Carrot", 2.99m });

            migrationBuilder.UpdateData(
                table: "GroceryListEntries",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Category", "Name", "Price", "Unit" },
                values: new object[] { "Drink", "Milk", 2.49m, "Pcs" });

            migrationBuilder.UpdateData(
                table: "GroceryListEntries",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Category", "Name", "Price", "Unit" },
                values: new object[] { "Drink", "Sprite", 6.50m, "Pcs" });

            migrationBuilder.UpdateData(
                table: "GroceryListEntries",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Category", "Name", "Price", "Unit" },
                values: new object[] { "Candy", "Skittles", 9.99m, "Pcs" });

            migrationBuilder.UpdateData(
                table: "GroceryListEntries",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Category", "Name", "Price", "Unit" },
                values: new object[] { "Candy", "Chocolate", 4.69m, "Pcs" });
        }
    }
}
