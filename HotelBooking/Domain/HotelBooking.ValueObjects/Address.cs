using HotelBooking.ValueObjects.Base;
using HotelBooking.ValueObjects.Validators;

namespace HotelBooking.ValueObjects;

public class Address(string country, string city, string street, string postalCode) 
    : ValueObject<(string Country, string City, string Street, string PostalCode)>
    (new AddressValidator(), (country, city, street, postalCode))
{
    public string Country => Value.Country;
    public string City => Value.City;
    public string Street => Value.Street;
    public string PostalCode => Value.PostalCode;
    
    public override string ToString() => $"{Street}, {City}, {Country}, {PostalCode}";
}
