using HotelBooking.ValueObjects.Base;
using HotelBooking.ValueObjects.Validators;

namespace HotelBooking.ValueObjects;

public class DateRange(DateTime checkIn, DateTime checkOut) : ValueObject<(DateTime CheckIn, DateTime CheckOut)>
    (new DateRangeValidator(), (checkIn, checkOut))
{
    public DateTime CheckIn => Value.CheckIn;
    public DateTime CheckOut => Value.CheckOut;
    
    public int NumberOfNights => (CheckOut - CheckIn).Days;
}
