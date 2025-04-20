using Domain.Aggregates;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

            builder.OwnsOne(f => f.CurrentBalance, money =>
            {
                money.Property(m => m.Amount)
                    .HasColumnName("CurrentBalance")
                    .HasPrecision(18, 2)
                    .IsRequired();

                money.Property(m => m.Currency)
                    .HasColumnName("Currency")
                    .IsRequired();
            });

            builder.HasIndex(f => f.AdmissionNumber);
        }
    }
}
