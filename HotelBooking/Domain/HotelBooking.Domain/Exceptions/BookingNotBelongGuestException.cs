namespace HotelBooking.Domain.Exceptions;

public class BookingNotBelongGuestException(Booking booking, Guest guest)
    : InvalidOperationException(
        $"The booking {booking.Id} does not belong to guest {guest.Name}.")
{
    public Booking Booking => booking;
    public Guest Guest => guest;
}
