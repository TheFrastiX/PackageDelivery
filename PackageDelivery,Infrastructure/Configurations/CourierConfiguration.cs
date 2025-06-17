using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DeliveryParcel.Domain.Entities;

namespace DeliveryParcel.Infrastructure.Configurations
{
    public class CourierConfiguration : IEntityTypeConfiguration<Courier>
    {
        public void Configure(EntityTypeBuilder<Courier> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.PhoneNumber).IsRequired();
            builder.Property(c => c.SenderAddress).IsRequired().HasMaxLength(200);
            builder.Property(c => c.RecipientAddress).IsRequired().HasMaxLength(200);
            builder.Property(c => c.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
