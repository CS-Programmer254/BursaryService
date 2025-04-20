using Domain.Aggregates;
using Domain.Data.Configurations;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<BursaryApplication>? BursaryApplications { get; set; }
        public DbSet<BursaryApproval>? BursaryApprovals { get; set; }
        public DbSet<FeeBalance>? FeeBalances { get; set; }
        public DbSet<FamilyStatus>? FamilyStatuses { get; set; }
        public DbSet<FinancialSponsorship>? FinancialSponsorships { get; set; }
        public DbSet<Parent>? Parents { get; set; }
        public DbSet<BursaryApprovalStatus>? BursaryApprovalStatuses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BursaryApplicationConfiguration());
            modelBuilder.ApplyConfiguration(new BursaryApprovalConfiguration());
            modelBuilder.ApplyConfiguration(new FeeBalanceConfiguration());
            modelBuilder.ApplyConfiguration(new FinancialSponsorshipConfiguration());

            modelBuilder.Entity<BursaryApplication>()
                .OwnsOne(b => b.AmountAppliedFor, amount =>
                {
                    amount.Property(a => a.Amount)
                        .HasColumnName("AmountAppliedFor")
                        .IsRequired();

                    amount.Property(a => a.Currency)
                        .HasColumnName("AmountAppliedFor_Currency") 
                        .IsRequired();
                });

            modelBuilder.Entity<BursaryApproval>()
                .OwnsOne(b => b.AmountAppliedFor, amount =>
                {
                    amount.Property(a => a.Amount)
                        .HasColumnName("AmountAppliedFor")
                        .IsRequired();

                    amount.Property(a => a.Currency)
                        .HasColumnName("AmountAppliedFor_Currency") 
                        .IsRequired();
                });

            modelBuilder.Entity<BursaryApproval>()
                .OwnsOne(b => b.AmountAllocated, amount =>
                {
                    amount.Property(a => a.Amount)
                        .HasColumnName("AmountAllocated")
                        .IsRequired();

                    amount.Property(a => a.Currency)
                        .HasColumnName("AmountAllocated_Currency") 
                        .IsRequired();
                });

            modelBuilder.Entity<FinancialSponsorship>()
                .OwnsOne(f => f.AmountFunded, amount =>
                {
                    amount.Property(a => a.Amount)
                        .HasColumnName("AmountFunded")
                        .IsRequired();

                    amount.Property(a => a.Currency)
                        .HasColumnName("AmountFunded_Currency")
                        .IsRequired();
                });

            modelBuilder.Entity<FeeBalance>()
                .OwnsOne(f => f.CurrentBalance, amount =>
                {
                    amount.Property(a => a.Amount)
                        .HasColumnName("FeeBalance_CurrentBalance")
                        .IsRequired();

                    amount.Property(a => a.Currency)
                        .HasColumnName("FeeBalance_Currency")
                        .IsRequired();
                });

            base.OnModelCreating(modelBuilder);
        }

      
    }
}
