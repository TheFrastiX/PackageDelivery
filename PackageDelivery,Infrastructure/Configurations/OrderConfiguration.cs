using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DeliveryParcel.Domain.Entities;

namespace DeliveryParcel.Infrastructure.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedNever();

            builder.Property(o => o.SenderAddress).IsRequired().HasMaxLength(200);
            builder.Property(o => o.RecipientAddress).IsRequired().HasMaxLength(200);
            builder.Property(o => o.WeightKg).HasColumnType("decimal(18,2)");
            builder.Property(o => o.Dimensions).HasMaxLength(50);
            builder.Property(o => o.Price).HasColumnType("decimal(10,2)");
            builder.Property(o => o.Status).IsRequired();
            builder.Property(o => o.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(o => o.DeliveredAt).IsRequired(false);
        }
    }
}
