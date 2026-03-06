using HotelBooking.Domain;
using HotelBooking.Domain.Repositories.Abstractions.Base;

namespace HotelBooking.Domain.Repositories.Abstractions;

/// <summary>
/// Repository interface for Booking entity.
/// </summary>
public interface IBookingRepository : IRepository<Booking, Guid>
{
    /// <summary>
    /// Gets all bookings for a specific guest.
    /// </summary>
    /// <param name="guestId">Guest ID.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Collection of bookings.</returns>
    Task<IEnumerable<Booking>> GetByGuestIdAsync(Guid guestId, CancellationToken cancellationToken);

    /// <summary>
    /// Gets bookings by date range.
    /// </summary>
    /// <param name="checkIn">Check-in date.</param>
    /// <param name="checkOut">Check-out date.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Collection of bookings.</returns>
    Task<IEnumerable<Booking>> GetByDateRangeAsync(
        DateTime checkIn,
        DateTime checkOut,
        CancellationToken cancellationToken);

    /// <summary>
    /// Gets bookings by status.
    /// </summary>
    /// <param name="status">Booking status.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Collection of bookings.</returns>
    Task<IEnumerable<Booking>> GetByStatusAsync(
        Enums.BookingStatus status,
        CancellationToken cancellationToken);

    /// <summary>
    /// Gets active bookings (not cancelled or completed).
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Collection of active bookings.</returns>
    Task<IEnumerable<Booking>> GetActiveBookingsAsync(CancellationToken cancellationToken);
}
