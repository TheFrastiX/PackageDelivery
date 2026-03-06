using HotelBooking.ValueObjects.Base;
using HotelBooking.ValueObjects.Validators;

namespace HotelBooking.ValueObjects;

public class Price(decimal amount, string currency = "USD") : ValueObject<(decimal Amount, string Currency)>
    (new PriceValidator(), (amount, currency))
{
    public decimal Amount => Value.Amount;
    public string Currency => Value.Currency;
    
    public override string ToString() => $"{Amount:F2} {Currency}";
}
