using Microsoft.EntityFrameworkCore;
using Assignment_1.Models;

namespace Assignment_1.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserEntry> Users { get; set; }
        public DbSet<InvoiceEntry> Invoices { get; set; }

        private readonly string _databasePath;

        public AppDbContext(DbContextOptions<AppDbContext> options, string databasePath) : base(options)
        {
            _databasePath = databasePath;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite($"Filename={_databasePath}");
            }
        }

        public void EnsureDatabaseCreated()
        {
            Database.EnsureCreated(); 
        }
    }
}
