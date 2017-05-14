
using Microsoft.EntityFrameworkCore;
using QuizApp.Models;

namespace QuizApp.DB
{
    public class QuizAppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=QuizApp;Integrated Security=True");
        }

        public DbSet<Genre> Genre { get; set; }
        public DbSet<Test> Test { get; set; }
    }
}
