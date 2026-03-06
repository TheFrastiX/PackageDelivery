public class Guest(Guid id, GuestName name, Email email) : Entity<Guid>(id)
{
    private readonly ICollection<Booking> _bookings = [];
    
    public GuestName Name { get; private set; } = name;
    public Email Email { get; private set; } = email;
    public IReadOnlyCollection<Booking> Bookings => _bookings.ToList().AsReadOnly();

    public Booking CreateBooking(DateRange dates, Price price, RoomNumber roomNumber)
    {
        var booking = new Booking(this, dates, price, roomNumber, DateTime.UtcNow);
        _bookings.Add(booking);
        return booking;
    }
    
    // ... методы EditBooking, CancelBooking с валидацией
}
