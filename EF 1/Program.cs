

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace EF_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new AppDbContext();

            context.Database.EnsureCreated();

            Console.WriteLine("Database Created Successfully!");

        }
    }

    #region Models

    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string ISBN { get; set; }
        public double Price { get; set; }
        public int Pages { get; set; }
        public int Year { get; set; }
        public bool InStock { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }

    public class Author
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
        public DateTime DateOfBirth { get; set; }

        public List<Book> Books { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public List<Book> Books { get; set; }
    }

    #endregion

    #region DbContext

    public class AppDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=.;Database=BookStoreDB;Trusted_Connection=True;TrustServerCertificate=True"
            );
        }
    }

    #endregion
}
