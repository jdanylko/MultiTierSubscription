using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MultiTierSubscriptionExample.Models;

namespace MultiTierSubscriptionExample.Data
{
    public class ApplicationDbContext : DbContext, IFeatureDbContext
    {
        private readonly IConfiguration _config;

        public DbSet<Plan> Plans { get; set; }
        public DbSet<PlanFeature> PlanFeatures { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration config)
            : base(options)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;

            var connString = _config.GetConnectionString("DefaultConnection");
            if (!string.IsNullOrEmpty(connString))
            {
                optionsBuilder.UseSqlServer(connString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.HasDefaultSchema("core");

            modelBuilder.Entity<Plan>(entity =>
            {
                entity.ToTable("Plan", "dbo");

                entity.Property(e => e.PlanId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.PricePerMonth)
                    .IsRequired();

                entity.Property(e => e.PricePerYear)
                    .IsRequired();
            });

            modelBuilder.Entity<PlanFeature>(entity =>
            {
                entity.ToTable("PlanFeature", "dbo");

                entity.Property(e => e.FeatureId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.PlanId)
                    .IsRequired();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200);
            });
        }

    }
}
