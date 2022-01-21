using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Seeders
{
    class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                new Book
                {
                    CodBook = 001,
                    Title = "The Monk Who Sold His Ferrari",
                    Author = "Robin Sharma",
                    Publisher = "Jaiko Publishing House",
                    Genere = "Fiction",
                    Price = 141
                },
                new Book
                {
                    CodBook = 002,
                    Title = "The Theory Of Everything",
                    Author = "Stephen Hawking",
                    Publisher = "Jaiko Publishing House",
                    Genere = "Engenering & Technology",
                    Price = 147
                },
                new Book
                {
                    CodBook = 003,
                    Title = "Rich Dad Poor Dad",
                    Author = "Robert Kiyosaki",
                    Publisher = "Plata Publishing",
                    Genere = "Personal Finance",
                    Price = 288
                });
        }
    }
}
