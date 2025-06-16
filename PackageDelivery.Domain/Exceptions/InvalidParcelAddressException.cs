using System;
using DeliveryParcel.Domain.ValueObjects;

namespace DeliveryParcel.Domain.Exceptions
{
    /// <summary>
    /// Thrown when a parcel address is invalid or incomplete.
    /// </summary>
    public class InvalidParcelAddressException : DomainException
    {
        public Address Address { get; }

        public InvalidParcelAddressException(Address address, string reason)
            : base($"Invalid parcel address: {address}. Reason: {reason}")
        {
            Address = address;
        }
    }
}
