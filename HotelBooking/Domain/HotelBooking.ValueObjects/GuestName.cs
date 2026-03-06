public class GuestName(string name) : ValueObject<string>(new GuestNameValidator(), name);

// Validator:
public class GuestNameValidator : IValidator<string>
{
    public void Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidValueException(nameof(GuestName), "Name cannot be empty");
        if (value.Length < 2 || value.Length > 100)
            throw new InvalidValueException(nameof(GuestName), "Name must be 2-100 characters");
    }
}
