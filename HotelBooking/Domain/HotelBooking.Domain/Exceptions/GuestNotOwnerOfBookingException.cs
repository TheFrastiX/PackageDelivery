namespace HotelBooking.Domain.Exceptions;

public class GuestNotOwnerOfBookingException(Booking booking, Guest guest)
    : InvalidOperationException(
        $"The guest {guest.Name} can't modify the booking {booking.Id} owned by {booking.Guest.Name}.")
{
    public Booking Booking => booking;
    public Guest Guest => guest;
}
