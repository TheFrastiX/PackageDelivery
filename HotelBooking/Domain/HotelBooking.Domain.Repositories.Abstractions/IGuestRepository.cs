using HotelBooking.Domain;
using HotelBooking.Domain.Repositories.Abstractions.Base;
using HotelBooking.ValueObjects;

namespace HotelBooking.Domain.Repositories.Abstractions;

/// <summary>
/// Repository interface for Guest aggregate root.
/// </summary>
public interface IGuestRepository : IRepository<Guest, Guid>
{
    /// <summary>
    /// Gets guest by email.
    /// </summary>
    /// <param name="email">Guest email.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Guest if found, otherwise null.</returns>
    Task<Guest?> GetByEmailAsync(Email email, CancellationToken cancellationToken);

    /// <summary>
    /// Gets guest by name.
    /// </summary>
    /// <param name="name">Guest name.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Guest if found, otherwise null.</returns>
    Task<Guest?> GetByNameAsync(GuestName name, CancellationToken cancellationToken);
}
