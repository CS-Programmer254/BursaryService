using Domain.Aggregates;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Data.Configurations
{
    public class BursaryApprovalConfiguration : IEntityTypeConfiguration<BursaryApproval>
    {
        public void Configure(EntityTypeBuilder<BursaryApproval> builder)
        {
            builder.ToTable("BursaryApprovals");

            builder.HasKey(b => b.ApprovalId);

            builder.Property(b => b.BursaryApplicationId)
                .IsRequired();

            builder.Property(b => b.ApproverFullName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(b => b.ApproverEmailAddress)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(b => b.ApprovalStatus)
                .IsRequired()
                .HasMaxLength(50);

            //builder.OwnsOne(b => b.AmountAllocated, money =>
            //{
            //    money.Property(m => m.Amount)
            //        .HasColumnName("AmountAllocated")
            //        .HasPrecision(18, 2)
            //        .IsRequired();

            //    money.Property(m => m.Currency)
            //        .HasColumnName("Currency")
            //        .IsRequired();
            //});

            builder.HasOne(b => b.BursaryApplication)
                .WithOne(a => a.BursaryApproval)
                .HasForeignKey<BursaryApproval>(b => b.BursaryApplicationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
