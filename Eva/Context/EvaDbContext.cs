using Eva.Models;
using Microsoft.EntityFrameworkCore;

namespace Eva.Context
{
    public class EvaDbContext : DbContext
    {
        public EvaDbContext(DbContextOptions options ) : base(options) { }
        public DbSet<User> users { get; set; }
        public DbSet<Share> Shares { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Trade> Trades { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Share>().HasData(
                new Share { Symbol = "AAA", Price = 100.00m },
                new Share { Symbol = "BBB", Price = 200.00m },
                new Share { Symbol = "CCC", Price = 300.00m }
            );

            modelBuilder.Entity<Portfolio>().HasData(
              new Portfolio { PortfolioId = 1, UserEmail = "user1@example.com" },
              new Portfolio { PortfolioId = 2, UserEmail = "user2@example.com" },
              new Portfolio { PortfolioId = 3, UserEmail = "user3@example.com" }
          );
        }
    }
}
