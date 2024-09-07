using BookHive.DBClient.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace BookHive.DBClient.Repositories
{
    public class EFDbContext : DbContext
    {
        public EFDbContext(DbContextOptions<EFDbContext> options) : base(options) { }

        public DbSet<Sample> Samples { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){}
    }
}
