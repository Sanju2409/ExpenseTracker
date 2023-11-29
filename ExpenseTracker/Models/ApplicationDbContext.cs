using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Models
{
    public class ApplicationDbContext:DbContext //inheriting DbContext base class
    {
        public ApplicationDbContext(DbContextOptions options):base(options) //instance of this will be created ,that can be done using dependency injection in program.cs
        {

        }
        public DbSet<Transaction> Transactions { get; set; } //tables corresponding to these two will be named as transactions and categories
        public DbSet<Category> Categories { get; set; }
    }
}
