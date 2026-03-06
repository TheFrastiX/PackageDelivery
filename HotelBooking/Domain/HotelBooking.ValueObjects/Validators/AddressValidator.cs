using HotelBooking.ValueObjects.Base;

namespace HotelBooking.ValueObjects.Validators;

public class AddressValidator : IValidator<(string Country, string City, string Street, string PostalCode)>
{
    public void Validate((string Country, string City, string Street, string PostalCode) value)
    {
        if (string.IsNullOrWhiteSpace(value.Country))
            throw new ArgumentException("Country cannot be empty", nameof(value));
        if (value.Country.Length > 100)
            throw new ArgumentException("Country name is too long", nameof(value));
        
        if (string.IsNullOrWhiteSpace(value.City))
            throw new ArgumentException("City cannot be empty", nameof(value));
        if (value.City.Length > 100)
            throw new ArgumentException("City name is too long", nameof(value));
        
        if (string.IsNullOrWhiteSpace(value.Street))
            throw new ArgumentException("Street cannot be empty", nameof(value));
        if (value.Street.Length > 200)
            throw new ArgumentException("Street name is too long", nameof(value));
        
        if (string.IsNullOrWhiteSpace(value.PostalCode))
            throw new ArgumentException("Postal code cannot be empty", nameof(value));
        if (value.PostalCode.Length > 20)
            throw new ArgumentException("Postal code is too long", nameof(value));
    }
}
