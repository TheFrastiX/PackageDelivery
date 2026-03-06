using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using HotelBooking.Domain;
using HotelBooking.ValueObjects;
using HotelBooking.ValueObjects.Validators;

namespace HotelBooking.Infrastructure.Configurations;

public class GuestConfiguration : IEntityTypeConfiguration<Guest>
{
    public void Configure(EntityTypeBuilder<Guest> builder)
    {
        builder.HasKey(g => g.Id);
        builder.Property(g => g.Id).IsRequired();

        // Value Object: GuestName
        builder.OwnsOne(g => g.Name, name =>
        {
            name.Property(n => n.Value)
                .HasColumnName("Name")
                .IsRequired()
                .HasMaxLength(GuestNameValidator.MAX_LENGTH);
        });

        // Value Object: Email
        builder.OwnsOne(g => g.Email, email =>
        {
            email.Property(e => e.Value)
                .HasColumnName("Email")
                .IsRequired()
                .HasMaxLength(EmailValidator.MAX_LENGTH);
        });

        // Навигационное свойство к броням
        builder.HasMany(g => g.Bookings)
            .WithOne(b => b.Guest)
            .HasForeignKey("GuestId")
            .OnDelete(DeleteBehavior.Cascade);

        // Игнорируем свойство (доступ через навигацию)
        builder.Ignore(g => g.Bookings);
    }
}
