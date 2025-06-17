using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DeliveryParcel.Domain.Entities;

namespace DeliveryParcel.Infrastructure.Configurations
{
    public class TrackingConfiguration : IEntityTypeConfiguration<Tracking>
    {
        public void Configure(EntityTypeBuilder<Tracking> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Description).HasMaxLength(300);
            builder.Property(t => t.Timestamp).HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
