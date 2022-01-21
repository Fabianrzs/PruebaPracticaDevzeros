using DAL.Seeders;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions contextOptions):base(contextOptions) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
