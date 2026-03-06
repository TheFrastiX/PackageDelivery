using HotelBooking.ValueObjects.Base;

namespace HotelBooking.ValueObjects.Validators;

public class DateRangeValidator : IValidator<(DateTime CheckIn, DateTime CheckOut)>
{
    public void Validate((DateTime CheckIn, DateTime CheckOut) value)
    {
        if (value.CheckIn >= value.CheckOut)
            throw new ArgumentException("Check-out date must be after check-in date", nameof(value));
        
        if (value.CheckIn.Date < DateTime.Today)
            throw new ArgumentException("Check-in date cannot be in the past", nameof(value));
        
        if ((value.CheckOut - value.CheckIn).Days < 1)
            throw new ArgumentException("Minimum stay is 1 night", nameof(value));
        
        if ((value.CheckOut - value.CheckIn).Days > 90)
            throw new ArgumentException("Maximum stay is 90 nights", nameof(value));
    }
}
