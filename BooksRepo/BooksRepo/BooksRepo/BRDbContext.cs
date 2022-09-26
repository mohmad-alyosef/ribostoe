using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksRepo.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksRepo
{
    public class BRDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public BRDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlServer(@"Data Source=localhost;Initial Catalog=BookRepo;Integrated Security=True;");
    }
}
