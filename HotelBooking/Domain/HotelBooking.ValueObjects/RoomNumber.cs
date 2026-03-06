using HotelBooking.ValueObjects.Base;
using HotelBooking.ValueObjects.Validators;

namespace HotelBooking.ValueObjects;

public class RoomNumber(string number) : ValueObject<string>(new RoomNumberValidator(), number);
