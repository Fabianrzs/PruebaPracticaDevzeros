using Entity;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL
{
    public class PruebaContext:DbContext
    {
        public PruebaContext(DbContextOptions contextOptions):base(contextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                    new { Email = "admin@admin.com", UserName = "Admin", 
                        Password = "Admin", Rol = "Admin" });

            modelBuilder.Entity<Book>().HasData(
                new { CodBook = 001, Title = "The Monk Who Sold His Ferrari", 
                    Author = "Robin Sharma", Publisher = "Jaiko Publishing House", 
                    Genere = "Fiction", Price = 141},
                new { CodBook = 002, Title = "The Theory Of Everything", 
                    Author = "Stephen Hawking", Publisher = "Jaiko Publishing House", 
                    Genere = "Engenering & Technology", Price = 141 },
                new { CodBook = 003, Title = "Rich Dad Poor Dad", 
                    Author = "Robert Kiyosaki", Publisher = "Plata Publishing", 
                    Genere = "Personal Finance", Price = 288 });  
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
