using HotelBooking.ValueObjects.Base;
using HotelBooking.ValueObjects.Validators;

namespace HotelBooking.ValueObjects;

public class GuestName(string name) : ValueObject<string>(new GuestNameValidator(), name);
