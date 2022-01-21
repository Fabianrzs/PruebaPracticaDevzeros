using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class SeederInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    CodBook = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genere = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.CodBook);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rol = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserName);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "CodBook", "Author", "Genere", "Price", "Publisher", "Title" },
                values: new object[,]
                {
                    { 1, "Robin Sharma", "Fiction", 141, "Jaiko Publishing House", "The Monk Who Sold His Ferrari" },
                    { 2, "Stephen Hawking", "Engenering & Technology", 141, "Jaiko Publishing House", "The Theory Of Everything" },
                    { 3, "Robert Kiyosaki", "Personal Finance", 288, "Plata Publishing", "Rich Dad Poor Dad" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserName", "Email", "Password", "Rol" },
                values: new object[] { "Admin", "admin@admin.com", "Admin", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
