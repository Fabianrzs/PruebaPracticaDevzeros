using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserRoleCodUserRole",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RolePermission",
                columns: table => new
                {
                    CodRolePermission = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermission", x => x.CodRolePermission);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    CodUserRole = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.CodUserRole);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    CodPermission = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamePermission = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescripcionPermission = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RolePermissionCodRolePermission = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.CodPermission);
                    table.ForeignKey(
                        name: "FK_Permission_RolePermission_RolePermissionCodRolePermission",
                        column: x => x.RolePermissionCodRolePermission,
                        principalTable: "RolePermission",
                        principalColumn: "CodRolePermission",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    CodRole = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RolePermissionCodRolePermission = table.Column<int>(type: "int", nullable: true),
                    UserRoleCodUserRole = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.CodRole);
                    table.ForeignKey(
                        name: "FK_Role_RolePermission_RolePermissionCodRolePermission",
                        column: x => x.RolePermissionCodRolePermission,
                        principalTable: "RolePermission",
                        principalColumn: "CodRolePermission",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Role_UserRole_UserRoleCodUserRole",
                        column: x => x.UserRoleCodUserRole,
                        principalTable: "UserRole",
                        principalColumn: "CodUserRole",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserRoleCodUserRole",
                table: "Users",
                column: "UserRoleCodUserRole");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_RolePermissionCodRolePermission",
                table: "Permission",
                column: "RolePermissionCodRolePermission");

            migrationBuilder.CreateIndex(
                name: "IX_Role_RolePermissionCodRolePermission",
                table: "Role",
                column: "RolePermissionCodRolePermission");

            migrationBuilder.CreateIndex(
                name: "IX_Role_UserRoleCodUserRole",
                table: "Role",
                column: "UserRoleCodUserRole");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserRole_UserRoleCodUserRole",
                table: "Users",
                column: "UserRoleCodUserRole",
                principalTable: "UserRole",
                principalColumn: "CodUserRole",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserRole_UserRoleCodUserRole",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "RolePermission");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserRoleCodUserRole",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserRoleCodUserRole",
                table: "Users");
        }
    }
}
