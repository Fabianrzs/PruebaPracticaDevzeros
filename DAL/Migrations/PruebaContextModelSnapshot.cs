﻿// <auto-generated />
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(PruebaContext))]
    partial class PruebaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                            Price = 141,
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

                    b.HasKey("UserName");

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
#pragma warning restore 612, 618
        }
    }
}
