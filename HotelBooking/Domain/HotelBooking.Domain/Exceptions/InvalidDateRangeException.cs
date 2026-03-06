using HotelBooking.ValueObjects;

namespace HotelBooking.Domain.Exceptions;

public class InvalidDateRangeException(DateRange dateRange)
    : InvalidOperationException(
        $"Invalid date range: Check-out ({dateRange.CheckOut}) must be after Check-in ({dateRange.CheckIn})")
{
    public DateRange DateRange => dateRange;
}
