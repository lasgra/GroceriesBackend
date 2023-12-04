using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestProject.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroceryList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroceryList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroceryListEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GroceryListId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroceryListEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroceryListEntries_GroceryList_GroceryListId",
                        column: x => x.GroceryListId,
                        principalTable: "GroceryList",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "GroceryListEntries",
                columns: new[] { "Id", "Amount", "Category", "GroceryListId", "Name", "Price", "Unit" },
                values: new object[,]
                {
                    { 1, null, "Fruit", null, "Apple", 3.49m, "kg" },
                    { 2, null, "Fruit", null, "Banana", 6.99m, "kg" },
                    { 3, null, "Fruit", null, "Peach", 7.01m, "kg" },
                    { 4, null, "Vegetable", null, "Tomato", 12.49m, "kg" },
                    { 5, null, "Vegetable", null, "Carrot", 2.99m, "kg" },
                    { 6, null, "Drink", null, "Milk", 2.49m, "Pcs" },
                    { 7, null, "Drink", null, "Sprite", 6.50m, "Pcs" },
                    { 8, null, "Candy", null, "Skittles", 9.99m, "Pcs" },
                    { 9, null, "Candy", null, "Chocolate", 4.69m, "Pcs" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroceryListEntries_GroceryListId",
                table: "GroceryListEntries",
                column: "GroceryListId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroceryListEntries");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "GroceryList");
        }
    }
}
