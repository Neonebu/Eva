using Eva.Models;
using Microsoft.EntityFrameworkCore;

namespace Eva.Context
{
    public class EvaDbContext : DbContext
    {
        public EvaDbContext(DbContextOptions options ) : base(options) { }
        public DbSet<User> users { get; set; }
    }
}
