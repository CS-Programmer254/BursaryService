using Domain.Aggregates;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Data.Configurations
{
    public class FinancialSponsorshipConfiguration : IEntityTypeConfiguration<FinancialSponsorship>
    {
        public void Configure(EntityTypeBuilder<FinancialSponsorship> builder)
        {
            builder.ToTable("FinancialSponsorships");

            builder.HasKey(f => f.FinancialSponsorshipEntryId);

            builder.Property(f => f.AwardingOrganization)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(f => f.SponsorshipType)
                .IsRequired()
                .HasMaxLength(100);

            builder.OwnsOne(f => f.AmountFunded, money =>
            {
                money.Property(m => m.Amount)
                    .HasColumnName("AmountFunded")
                    .HasPrecision(18, 2)
                    .IsRequired();

                money.Property(m => m.Currency)
                    .HasColumnName("Currency")
                    .IsRequired();
            });

            builder.Property(f => f.AdmissionNumber)
                .IsRequired()
                .HasMaxLength(20);

            builder.HasIndex(f => f.AdmissionNumber);
        }
    }
}
