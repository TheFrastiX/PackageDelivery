using HotelBooking.ValueObjects.Base;

namespace HotelBooking.ValueObjects.Validators;

public class HotelNameValidator : IValidator<string>
{
    public void Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Hotel name cannot be empty", nameof(value));
        
        if (value.Length < 3 || value.Length > 200)
            throw new ArgumentException("Hotel name must be between 3 and 200 characters", nameof(value));
    }
}
