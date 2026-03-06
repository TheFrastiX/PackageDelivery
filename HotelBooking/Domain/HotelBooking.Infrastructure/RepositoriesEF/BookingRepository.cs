using Microsoft.EntityFrameworkCore;
using HotelBooking.Domain;
using HotelBooking.Domain.Enums;
using HotelBooking.Domain.Repositories.Abstractions;
using HotelBooking.Infrastructure.Data;

namespace HotelBooking.Infrastructure.Repositories;

public class BookingRepository(HotelBookingDbContext context)
    : EfRepository<Booking, Guid>(context), IBookingRepository
{
    private readonly DbSet<Booking> _bookings = context.Set<Booking>();

    public override Task<Booking?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        => _bookings.Include(b => b.Guest)
        .FirstOrDefaultAsync(b => b.Id == id, cancellationToken)!;

    public Task<List<Booking>> GetByGuestIdAsync(Guid guestId, CancellationToken cancellationToken)
        => _bookings.Include(b => b.Guest)
        .Where(b => EF.Property<Guid>(b, "GuestId") == guestId)
        .ToListAsync(cancellationToken);

    public Task<List<Booking>> GetByDateRangeAsync(DateTime checkIn, DateTime checkOut, CancellationToken cancellationToken)
        => _bookings.Include(b => b.Guest)
        .Where(b => b.DateRange.CheckIn <= checkOut && b.DateRange.CheckOut >= checkIn)
        .ToListAsync(cancellationToken);

    public Task<List<Booking>> GetByStatusAsync(BookingStatus status, CancellationToken cancellationToken)
        => _bookings.Include(b => b.Guest)
        .Where(b => b.Status == status)
        .ToListAsync(cancellationToken);

    public Task<List<Booking>> GetActiveBookingsAsync(CancellationToken cancellationToken)
        => _bookings.Include(b => b.Guest)
        .Where(b => b.Status == BookingStatus.Confirmed || b.Status == BookingStatus.CheckedIn)
        .ToListAsync(cancellationToken);
}
