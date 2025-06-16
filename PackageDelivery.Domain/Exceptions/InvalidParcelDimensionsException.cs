using System;

namespace DeliveryParcel.Domain.Exceptions
{
    /// <summary>
    /// Thrown when parcel dimensions are invalid or in incorrect format.
    /// </summary>
    public class InvalidParcelDimensionsException : DomainException
    {
        public string Dimensions { get; }

        public InvalidParcelDimensionsException(string dimensions)
            : base($"Invalid parcel dimensions: '{dimensions}'. Expected format: '30x40x50'.")
        {
            Dimensions = dimensions;
        }
    }
}
