using Domain.Aggregates;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            builder.Property(b => b.AmountAppliedFor)

                .HasConversion(

                    amount => amount.Amount, 

                    value => new Money(value, "KES") 
                )

                .IsRequired();

            builder.Property(b => b.ApplicationDate)

                .IsRequired();

    

            
            builder.HasIndex(b => b.ApplicationId);
        }
    }
}
