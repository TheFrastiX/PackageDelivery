using HotelBooking.ValueObjects.Base;
using HotelBooking.ValueObjects.Validators;

namespace HotelBooking.ValueObjects;

public class HotelName(string name) : ValueObject<string>(new HotelNameValidator(), name);
