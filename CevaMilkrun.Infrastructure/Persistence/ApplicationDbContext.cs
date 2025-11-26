using CevaMilkrun.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace CevaMilkrun.Infrastructure.Persistence
{
    // A classe deve herdar de DbContext
    public class ApplicationDbContext : DbContext
    {
        // O construtor deve repassar as opções para a base
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<SearchHistory> SearchHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Boa prática chamar o base

            modelBuilder.Entity<SearchHistory>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.PhoneNumber).HasMaxLength(20);
            });
        }
    }
}