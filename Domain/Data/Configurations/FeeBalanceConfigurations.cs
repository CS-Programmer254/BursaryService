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
    public class FeeBalanceConfiguration : IEntityTypeConfiguration<FeeBalance>
    {
        public void Configure(EntityTypeBuilder<FeeBalance> builder)
        {
            builder.ToTable("FeeBalances"); 

            builder.HasKey(f => f.Id); 

            builder.Property(f => f.AdmissionNumber)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(f => f.CurrentBalance)
                .IsRequired()
                .HasConversion(
                    balance => balance.Amount, 

                    value => new Money(value, "KES")
                )
                .IsRequired();

            builder.HasIndex(f => f.AdmissionNumber); 
        }
    }
}
