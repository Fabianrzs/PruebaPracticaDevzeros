// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220127211117_roles")]
    partial class roles
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entity.Book", b =>
                {
                    b.Property<int>("CodBook")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genere")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Publisher")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodBook");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            CodBook = 1,
                            Author = "Robin Sharma",
                            Genere = "Fiction",
                            Price = 141,
                            Publisher = "Jaiko Publishing House",
                            Title = "The Monk Who Sold His Ferrari"
                        },
                        new
                        {
                            CodBook = 2,
                            Author = "Stephen Hawking",
                            Genere = "Engenering & Technology",
                            Price = 147,
                            Publisher = "Jaiko Publishing House",
                            Title = "The Theory Of Everything"
                        },
                        new
                        {
                            CodBook = 3,
                            Author = "Robert Kiyosaki",
                            Genere = "Personal Finance",
                            Price = 288,
                            Publisher = "Plata Publishing",
                            Title = "Rich Dad Poor Dad"
                        });
                });

            modelBuilder.Entity("Entity.Permission", b =>
                {
                    b.Property<int>("CodPermission")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DescripcionPermission")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NamePermission")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RolePermissionCodRolePermission")
                        .HasColumnType("int");

                    b.HasKey("CodPermission");

                    b.HasIndex("RolePermissionCodRolePermission");

                    b.ToTable("Permission");
                });

            modelBuilder.Entity("Entity.Role", b =>
                {
                    b.Property<int>("CodRole")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NameRole")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RolePermissionCodRolePermission")
                        .HasColumnType("int");

                    b.Property<int?>("UserRoleCodUserRole")
                        .HasColumnType("int");

                    b.HasKey("CodRole");

                    b.HasIndex("RolePermissionCodRolePermission");

                    b.HasIndex("UserRoleCodUserRole");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Entity.RolePermission", b =>
                {
                    b.Property<int>("CodRolePermission")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("CodRolePermission");

                    b.ToTable("RolePermission");
                });

            modelBuilder.Entity("Entity.User", b =>
                {
                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserRoleCodUserRole")
                        .HasColumnType("int");

                    b.HasKey("UserName");

                    b.HasIndex("UserRoleCodUserRole");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserName = "Admin",
                            Email = "admin@admin.com",
                            Password = "Admin",
                            Rol = "Admin"
                        });
                });

            modelBuilder.Entity("Entity.UserRole", b =>
                {
                    b.Property<int>("CodUserRole")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("CodUserRole");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("Entity.Permission", b =>
                {
                    b.HasOne("Entity.RolePermission", "RolePermission")
                        .WithMany("Permissions")
                        .HasForeignKey("RolePermissionCodRolePermission");

                    b.Navigation("RolePermission");
                });

            modelBuilder.Entity("Entity.Role", b =>
                {
                    b.HasOne("Entity.RolePermission", "RolePermission")
                        .WithMany("Roles")
                        .HasForeignKey("RolePermissionCodRolePermission");

                    b.HasOne("Entity.UserRole", null)
                        .WithMany("Roles")
                        .HasForeignKey("UserRoleCodUserRole");

                    b.Navigation("RolePermission");
                });

            modelBuilder.Entity("Entity.User", b =>
                {
                    b.HasOne("Entity.UserRole", "UserRole")
                        .WithMany("Users")
                        .HasForeignKey("UserRoleCodUserRole");

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("Entity.RolePermission", b =>
                {
                    b.Navigation("Permissions");

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("Entity.UserRole", b =>
                {
                    b.Navigation("Roles");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
