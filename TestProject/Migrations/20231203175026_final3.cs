using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestProject.Migrations
{
    /// <inheritdoc />
    public partial class final3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "GroceryListEntries",
                columns: new[] { "Id", "Amount", "Category", "GroceryListId", "Name", "Price", "Unit" },
                values: new object[] { 20, null, "Candy", null, "M&M's", 8.65m, "Pcs" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GroceryListEntries",
                keyColumn: "Id",
                keyValue: 20);
        }
    }
}
