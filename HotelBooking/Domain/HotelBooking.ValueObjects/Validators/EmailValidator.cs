using HotelBooking.ValueObjects.Base;
using System.Text.RegularExpressions;

namespace HotelBooking.ValueObjects.Validators;

public class EmailValidator : IValidator<string>
{
    public void Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Email cannot be empty", nameof(value));
        
        var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        if (!Regex.IsMatch(value, emailPattern))
            throw new ArgumentException("Invalid email format", nameof(value));
        
        if (value.Length > 255)
            throw new ArgumentException("Email must not exceed 255 characters", nameof(value));
    }
}
