using HotelBooking.ValueObjects.Base;

namespace HotelBooking.ValueObjects.Validators;

public class GuestNameValidator : IValidator<string>
{
    public void Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Guest name cannot be empty", nameof(value));
        if (value.Length < 2 || value.Length > 100)
            throw new ArgumentException("Guest name must be between 2 and 100 characters", nameof(value));
    }
}
