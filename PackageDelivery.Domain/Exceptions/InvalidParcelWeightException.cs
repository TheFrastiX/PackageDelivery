using System;

namespace DeliveryParcel.Domain.Exceptions
{
    /// <summary>
    /// Thrown when parcel weight is less than or equal to zero.
    /// </summary>
    public class InvalidParcelWeightException : DomainException
    {
        public float WeightKg { get; }

        public InvalidParcelWeightException(float weightKg)
            : base($"Parcel weight must be greater than zero. Given value: {weightKg} kg.")
        {
            WeightKg = weightKg;
        }
    }
}
