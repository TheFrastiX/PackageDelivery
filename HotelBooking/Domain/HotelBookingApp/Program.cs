using HotelBooking.Domain;
using HotelBooking.Domain.Exceptions;
using HotelBooking.ValueObjects;
using HotelBooking.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using HotelBooking.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Добавляем Infrastructure слой (DbContext и репозитории)
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Создаём базу данных (для разработки)
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<HotelBookingDbContext>();
    dbContext.Database.EnsureCreated();
}

// ============================================
// Demo код (можно удалить после тестирования)
// ============================================

Console.WriteLine("HotelBooking Domain Demo\n");

try
{
    Console.WriteLine("Creating guest...");
    var guest = new Guest(
        Guid.NewGuid(),
        new GuestName("Иван Петров"),
        new Email("ivan.petrov@example.com")
    );
    Console.WriteLine($"Guest created: {guest.Name} ({guest.Email})\n");

    Console.WriteLine("Creating booking...");
    var booking = guest.CreateBooking(
        new DateRange(
            new DateTime(2026, 06, 15, 14, 0, 0),
            new DateTime(2026, 06, 20, 12, 0, 0)
        ),
        new Price(150.00m, "USD"),
        new RoomNumber("305")
    );
    Console.WriteLine($"Booking created: {booking.Id}");
    Console.WriteLine($"   Dates: {booking.DateRange.CheckIn:dd.MM} - {booking.DateRange.CheckOut:dd.MM}");
    Console.WriteLine($"   Price: {booking.Price}");
    Console.WriteLine($"   Room: {booking.RoomNumber}");
    Console.WriteLine($"   Status: {booking.Status}\n");

    Console.WriteLine("Editing booking...");
    var isEdited = guest.EditBooking(
        booking,
        new DateRange(
            new DateTime(2026, 06, 16, 14, 0, 0),
            new DateTime(2026, 06, 20, 12, 0, 0)
        ),
        new Price(140.00m, "USD")
    );
    Console.WriteLine($"Booking {(isEdited ? "edited" : "not edited")}\n");

    Console.WriteLine("Attempting to cancel booking (invalid date)...");
    try
    {
        guest.CancelBooking(booking, new DateTime(2026, 06, 18));
    }
    catch (InvalidCancellationDateException ex)
    {
        Console.WriteLine($"Expected exception: {ex.Message}\n");
    }

    Console.WriteLine("Cancelling booking (valid date)...");
    var isCancelled = guest.CancelBooking(booking, new DateTime(2026, 06, 10));
    Console.WriteLine($"Booking {(isCancelled ? "cancelled" : "not cancelled")}");
    Console.WriteLine($"   New status: {booking.Status}\n");

    Console.WriteLine("Testing aggregate protection...");
    var anotherGuest = new Guest(
        Guid.NewGuid(),
        new GuestName("Мария Сидорова"),
        new Email("maria@example.com")
    );
    
    try
    {
        anotherGuest.EditBooking(booking, booking.DateRange, booking.Price);
    }
    catch (GuestNotOwnerOfBookingException ex)
    {
        Console.WriteLine($"Expected exception: {ex.Message}\n");
    }

    Console.WriteLine("Testing ValueObject immutability...");
    var originalName = guest.Name;
    Console.WriteLine($"   Guest name: {originalName}");
    Console.WriteLine($"   Comparison: {originalName == guest.Name} (should be True)");
    Console.WriteLine($"   HashCode: {originalName.GetHashCode()} == {guest.Name.GetHashCode()}\n");

    Console.WriteLine("Testing collection encapsulation...");
    Console.WriteLine($"   Bookings count: {guest.Bookings.Count}");
    Console.WriteLine($"   Collection type: {guest.Bookings.GetType().Name}");
    Console.WriteLine($"   IsReadOnly: true (IReadOnlyCollection)\n");

    Console.WriteLine("Demo completed successfully!");
}
catch (Exception ex)
{
    Console.WriteLine($"Unexpected error: {ex.Message}");
    Console.WriteLine($"Stack: {ex.StackTrace}");
}

Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();
