using HotelBooking.ValueObjects.Base;
using System.Text.RegularExpressions;

namespace HotelBooking.ValueObjects.Validators;

public class PhoneNumberValidator : IValidator<string>
{
    public void Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Phone number cannot be empty", nameof(value));
        
        var phonePattern = @"^\+?[\d\s\-\(\)]{10,20}$";
        if (!Regex.IsMatch(value, phonePattern))
            throw new ArgumentException("Invalid phone number format", nameof(value));
    }
}
