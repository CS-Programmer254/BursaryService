using Domain.Aggregates;
using Domain.Data.Configurations;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext() { }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<BursaryApplication> BursaryApplications { get; set; }

        public DbSet<FeeBalance>?FeeBalances { get; set; }

        public DbSet<FamilyStatus>? FamilyStatuses { get; set; }

        public DbSet<FinancialSponsorship>? FinancialSponsorships { get; set; }

        public DbSet<Parent> Parents  { get; set; }

        public DbSet<BursaryApprovalStatus> ?  BursaryApprovalStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BursaryApplicationConfiguration());

            modelBuilder.ApplyConfiguration(new FeeBalanceConfiguration());

            modelBuilder.ApplyConfiguration(new FinancialSponsorshipConfiguration());
        }

    }
}
