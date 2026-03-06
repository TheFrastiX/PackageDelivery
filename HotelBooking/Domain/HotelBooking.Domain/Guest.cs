using HotelBooking.Domain.Base;
using HotelBooking.Domain.Exceptions;
using HotelBooking.ValueObjects;

namespace HotelBooking.Domain;

/// <summary>
/// Represents the guest (aggregate root).
/// </summary>
public class Guest(Guid id, GuestName name, Email email) : Entity<Guid>(id)
{
    /// <summary> 
    /// The guest's bookings.
    /// </summary>
    private readonly ICollection<Booking> _bookings = [];

    /// <summary> 
    /// Gets the guest's Name. 
    /// </summary>
    public GuestName Name { get; private set; } = name ?? throw new ArgumentNullValueException(nameof(name));

    /// <summary> 
    /// Gets the guest's Email. 
    /// </summary>
    public Email Email { get; private set; } = email ?? throw new ArgumentNullValueException(nameof(email));

    /// <summary>
    /// Gets the guest's bookings 
    /// </summary>
    public IReadOnlyCollection<Booking> Bookings => _bookings.ToList().AsReadOnly();

    /// <summary> 
    /// Changes the guest's name. 
    /// </summary>
    /// <param name="newName">New guest's name.</param>
    internal bool ChangeName(GuestName newName)
    {
        if (newName == null) throw new ArgumentNullValueException(nameof(newName));

        if (Name == newName) return false;

        Name = newName;
        return true;
    }

    /// <summary>
    /// Creates a new booking for this guest.
    /// </summary>
    public Booking CreateBooking(DateRange dates, Price price, RoomNumber roomNumber)
    {
        var booking = new Booking(this, dates, price, roomNumber, DateTime.UtcNow);
        _bookings.Add(booking);
        return booking;
    }

    /// <summary>
    /// Edits an existing booking.
    /// </summary>
    public bool EditBooking(Booking booking, DateRange newDates, Price newPrice)
    {
        if (booking.Guest != this) throw new GuestNotOwnerOfBookingException(booking, this);

        if (!_bookings.Contains(booking)) throw new BookingNotBelongGuestException(booking, this);

        var isEdit = booking.SetDateRange(newDates) || booking.SetPrice(newPrice);

        if (isEdit) booking.SetModificationDate(DateTime.UtcNow);

        return isEdit;
    }

    /// <summary>
    /// Cancels a booking.
    /// </summary>
    public bool CancelBooking(Booking booking, DateTime cancellationDate)
    {
        if (booking.Guest != this) throw new GuestNotOwnerOfBookingException(booking, this);

        if (!_bookings.Contains(booking)) throw new BookingNotBelongGuestException(booking, this);

        return booking.Cancel(cancellationDate);
    }

    /// <summary>
    /// Deletes a booking.
    /// </summary>
    public void DeleteBooking(Booking booking)
    {
        if (booking.Guest != this) throw new GuestNotOwnerOfBookingException(booking, this);

        if (!_bookings.Contains(booking)) throw new BookingNotBelongGuestException(booking, this);

        _bookings.Remove(booking);
    }
}
