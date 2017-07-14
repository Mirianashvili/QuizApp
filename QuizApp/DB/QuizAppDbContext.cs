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
        public DbSet<Question> Question { get; set; }
        public DbSet<Answer> Answer { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<TestResult> TestResult { get; set; }
    }
}
