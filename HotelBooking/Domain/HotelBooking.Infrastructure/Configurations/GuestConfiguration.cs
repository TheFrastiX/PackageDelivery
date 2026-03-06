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

        // Value Object: GuestName с конвертацией
        builder.Property(g => g.Name)
            .IsRequired()
            .HasConversion(
                name => name.Value,
                str => new GuestName(str))
            .HasMaxLength(GuestNameValidator.MAX_LENGTH)
            .HasColumnName("Name");

        // Value Object: Email с конвертацией
        builder.Property(g => g.Email)
            .IsRequired()
            .HasConversion(
                email => email.Value,
                str => new Email(str))
            .HasMaxLength(EmailValidator.MAX_LENGTH)
            .HasColumnName("Email");

        // Навигационное свойство к броням (через приватное поле)
        builder.HasMany<Booking>("_bookings")
            .WithOne(b => b.Guest)
            .HasForeignKey("GuestId")
            .HasPrincipalKey(g => g.Id)
            .OnDelete(DeleteBehavior.Cascade);

        // Игнорируем публичное свойство
        builder.Ignore(g => g.Bookings);
    }
}
