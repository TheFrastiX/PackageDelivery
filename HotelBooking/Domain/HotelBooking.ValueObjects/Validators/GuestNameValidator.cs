using HotelBooking.ValueObjects.Base;

namespace HotelBooking.ValueObjects.Validators;


public class GuestNameValidator : IValidator<string>
{
    public const int MAX_LENGTH = 100;
    
    public void Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Guest name cannot be empty", nameof(value));
        if (value.Length < 2 || value.Length > MAX_LENGTH)
            throw new ArgumentException($"Guest name must be between 2 and {MAX_LENGTH} characters", nameof(value));
    }
}
