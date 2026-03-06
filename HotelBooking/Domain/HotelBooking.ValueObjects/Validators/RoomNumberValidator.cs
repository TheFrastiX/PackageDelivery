using HotelBooking.ValueObjects.Base;

namespace HotelBooking.ValueObjects.Validators;

public class RoomNumberValidator : IValidator<string>
{
    public void Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Room number cannot be empty", nameof(value));
        
        if (value.Length < 1 || value.Length > 10)
            throw new ArgumentException("Room number must be between 1 and 10 characters", nameof(value));
    }
}
public class RoomNumberValidator : IValidator<string>
{
    public const int MAX_LENGTH = 10;
    
    public void Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Room number cannot be empty", nameof(value));
        
        if (value.Length < 1 || value.Length > MAX_LENGTH)
            throw new ArgumentException($"Room number must be between 1 and {MAX_LENGTH} characters", nameof(value));
    }
}
