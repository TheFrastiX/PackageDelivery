using HotelBooking.ValueObjects.Base;
using HotelBooking.ValueObjects.Validators;
using System.Text.RegularExpressions;

namespace HotelBooking.ValueObjects;

public class Email(string value) : ValueObject<string>(new EmailValidator(), value);
