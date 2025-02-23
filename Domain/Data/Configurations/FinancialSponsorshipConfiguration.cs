using Domain.Aggregates;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ValueObjects;

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

            builder.Property(f => f.AmountFunded)
                .HasConversion(
                    amount => amount.Amount,
                    value => new Money(value, "KES")
                )
                .IsRequired();

            builder.Property(f => f.AdmissionNumber)
                .IsRequired()
                .HasMaxLength(20); 

            builder.HasIndex(f => f.AdmissionNumber);
        }
    }
}
