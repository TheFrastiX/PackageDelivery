using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DeliveryParcel.Domain.Entities;

namespace DeliveryParcel.Infrastructure.Configurations
{
    public class RecipientConfiguration : IEntityTypeConfiguration<Recipient>
    {
        public void Configure(EntityTypeBuilder<Recipient> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.FirstName).IsRequired().HasMaxLength(30);
            builder.Property(r => r.LastName).HasMaxLength(30);
            builder.Property(r => r.Email).IsRequired().HasMaxLength(100);
            builder.Property(r => r.PhoneNumber).IsRequired();
            builder.Property(r => r.SenderId).IsRequired();
        }
    }
}
