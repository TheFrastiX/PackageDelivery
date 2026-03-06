using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using HotelBooking.Domain;
using HotelBooking.Domain.Enums;
using HotelBooking.ValueObjects;
using HotelBooking.ValueObjects.Validators;

namespace HotelBooking.Infrastructure.Configurations;

public class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id).IsRequired();

        // Foreign Key
        builder.Property<Guid>("GuestId")
            .IsRequired()
            .HasColumnName("GuestId");

        // Value Object: DateRange
        builder.OwnsOne(b => b.DateRange, dateRange =>
        {
            dateRange.Property(dr => dr.CheckIn)
                .HasColumnName("CheckInDate")
                .IsRequired()
                .HasConversion(
                    src => src.Kind == DateTimeKind.Utc ? src : DateTime.SpecifyKind(src, DateTimeKind.Utc),
                    dst => dst.Kind == DateTimeKind.Utc ? dst : DateTime.SpecifyKind(dst, DateTimeKind.Utc)
                );

            dateRange.Property(dr => dr.CheckOut)
                .HasColumnName("CheckOutDate")
                .IsRequired()
                .HasConversion(
                    src => src.Kind == DateTimeKind.Utc ? src : DateTime.SpecifyKind(src, DateTimeKind.Utc),
                    dst => dst.Kind == DateTimeKind.Utc ? dst : DateTime.SpecifyKind(dst, DateTimeKind.Utc)
                );
        });

        // Value Object: Price
        builder.OwnsOne(b => b.Price, price =>
        {
            price.Property(p => p.Amount)
                .HasColumnName("PriceAmount")
                .IsRequired()
                .HasPrecision(18, 2);

            price.Property(p => p.Currency)
                .HasColumnName("Currency")
                .IsRequired()
                .HasMaxLength(3);
        });

        // Value Object: RoomNumber
        builder.OwnsOne(b => b.RoomNumber, roomNumber =>
        {
            roomNumber.Property(r => r.Value)
                .HasColumnName("RoomNumber")
                .IsRequired()
                .HasMaxLength(RoomNumberValidator.MAX_LENGTH);
        });

        // Простые свойства с конвертацией DateTime в UTC
        builder.Property(b => b.CreationDate)
            .IsRequired()
            .HasConversion(
                src => src.Kind == DateTimeKind.Utc ? src : DateTime.SpecifyKind(src, DateTimeKind.Utc),
                dst => dst.Kind == DateTimeKind.Utc ? dst : DateTime.SpecifyKind(dst, DateTimeKind.Utc)
            );

        builder.Property(b => b.ModificationDate)
            .IsRequired(false)
            .HasConversion(
                src => !src.HasValue ? src : src.Value.Kind == DateTimeKind.Utc ? src : DateTime.SpecifyKind(src.Value, DateTimeKind.Utc),
                dst => !dst.HasValue ? dst : dst.Value.Kind == DateTimeKind.Utc ? dst : DateTime.SpecifyKind(dst.Value, DateTimeKind.Utc)
            );

        // Enum: Status
        builder.Property(b => b.Status)
            .IsRequired()
            .HasConversion<string>();

        // Игнорируем навигационное свойство
        builder.Ignore(b => b.Guest);
    }
}
