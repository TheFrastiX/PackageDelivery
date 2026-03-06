using HotelBooking.ValueObjects.Base;
using HotelBooking.ValueObjects.Validators;

namespace HotelBooking.ValueObjects;

public class PhoneNumber(string number) : ValueObject<string>(new PhoneNumberValidator(), number);
