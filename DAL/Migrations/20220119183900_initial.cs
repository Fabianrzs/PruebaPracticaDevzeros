using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Genre",
                table: "Books",
                newName: "Genere");

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "CodBook", "Author", "Genere", "Price", "Publisher", "Title" },
                values: new object[] { 1, "Robin Sharma", "Fiction", 141, "Jaiko Publishing House", "The Monk Who Sold His Ferrari" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "CodBook", "Author", "Genere", "Price", "Publisher", "Title" },
                values: new object[] { 2, "Stephen Hawking", "Engenering & Technology", 141, "Jaiko Publishing House", "The Theory Of Everything" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "CodBook", "Author", "Genere", "Price", "Publisher", "Title" },
                values: new object[] { 3, "Robert Kiyosaki", "Personal Finance", 288, "Plata Publishing", "Rich Dad Poor Dad" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "CodBook",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "CodBook",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "CodBook",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "Genere",
                table: "Books",
                newName: "Genre");
        }
    }
}
