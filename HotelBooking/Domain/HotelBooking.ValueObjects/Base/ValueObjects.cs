public abstract class ValueObject<T>(IValidator<T> validator, T value)
{
    public T Value { get; } = Validate(validator, value);
    
    private static T Validate(IValidator<T> validator, T value)
    {
        if (value is null) throw new ArgumentNullValueException(nameof(value));
        validator.Validate(value);
        return value;
    }
    
    public override bool Equals(object? obj) => 
        obj is ValueObject<T> other && EqualityComparer<T>.Default.Equals(Value, other.Value);
    
    public override int GetHashCode() => 
        EqualityComparer<T>.Default.GetHashCode(Value);
    
    public static bool operator ==(ValueObject<T>? left, ValueObject<T>? right) => 
        Equals(left, right);
    
    public static bool operator !=(ValueObject<T>? left, ValueObject<T>? right) => 
        !Equals(left, right);
}
