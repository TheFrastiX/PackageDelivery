using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DeliveryParcel.Domain.Entities;

namespace DeliveryParcel.Infrastructure.Configurations
{
    public class SenderConfiguration : IEntityTypeConfiguration<Sender>
    {
        public void Configure(EntityTypeBuilder<Sender> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.FirstName).IsRequired().HasMaxLength(30);
            builder.Property(s => s.LastName).IsRequired().HasMaxLength(30);
            builder.Property(s => s.Email).IsRequired().HasMaxLength(100);
            builder.Property(s => s.PhoneNumber).IsRequired();
        }
    }
}
