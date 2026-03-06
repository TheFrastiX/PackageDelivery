using HotelBooking.ValueObjects.Base;

namespace HotelBooking.ValueObjects.Validators;

public class PriceValidator : IValidator<(decimal Amount, string Currency)>
{
    public void Validate((decimal Amount, string Currency) value)
    {
        if (value.Amount < 0)
            throw new ArgumentException("Price amount cannot be negative", nameof(value));
        
        if (value.Amount > 1_000_000)
            throw new ArgumentException("Price amount is too high", nameof(value));
        
        if (string.IsNullOrWhiteSpace(value.Currency))
            throw new ArgumentException("Currency cannot be empty", nameof(value));
        
        if (value.Currency.Length != 3)
            throw new ArgumentException("Currency must be a 3-letter ISO code", nameof(value));
    }
}
