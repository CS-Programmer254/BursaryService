using Domain.Aggregates;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Data.Configurations
{
    public class BursaryApplicationConfiguration : IEntityTypeConfiguration<BursaryApplication>
    {
        public void Configure(EntityTypeBuilder<BursaryApplication> builder)
        {
            builder.ToTable("BursaryApplications");

            builder.HasKey(b => b.ApplicationId);

            builder.Property(b => b.ApplicantPhoneNumber)
                .IsRequired();

            //builder.OwnsOne(b => b.AmountAppliedFor, money =>
            //{
            //    money.Property(m => m.Amount)
            //        .HasColumnName("AmountAppliedFor")
            //        .HasPrecision(18, 2)
            //        .IsRequired();

            //    money.Property(m => m.Currency)
            //        .HasColumnName("Currency")
            //        .IsRequired();
            //});

            builder.Property(b => b.ApplicationDate)
                .IsRequired();

            builder.HasIndex(b => b.ApplicationId);
        }
    }
}
