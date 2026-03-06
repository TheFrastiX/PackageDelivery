namespace HotelBooking.ValueObjects.Exceptions;

public class ValidatorNullException(string paramName)
    : ArgumentNullException(paramName, "Validator cannot be null");
