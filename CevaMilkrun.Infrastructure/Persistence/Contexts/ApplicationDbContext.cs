using CevaMilkrun.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CevaMilkrun.Infrastructure.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<SearchHistory> SearchHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SearchHistory>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.PhoneNumber).HasMaxLength(20);
            });
        }
    }
}