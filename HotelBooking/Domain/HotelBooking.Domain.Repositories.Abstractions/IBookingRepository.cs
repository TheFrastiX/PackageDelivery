using HotelBooking.Domain;
using HotelBooking.Domain.Repositories.Abstractions.Base;

namespace HotelBooking.Domain.Repositories.Abstractions;

public interface IBookingRepository : IRepository<Booking, Guid>
{
    Task<List<Booking>> GetByGuestIdAsync(Guid guestId, CancellationToken cancellationToken);
    Task<List<Booking>> GetByDateRangeAsync(DateTime checkIn, DateTime checkOut, CancellationToken cancellationToken);
    Task<List<Booking>> GetByStatusAsync(Enums.BookingStatus status, CancellationToken cancellationToken);
    Task<List<Booking>> GetActiveBookingsAsync(CancellationToken cancellationToken);
}
