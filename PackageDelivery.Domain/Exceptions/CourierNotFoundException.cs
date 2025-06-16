using System;

namespace DeliveryParcel.Domain.Exceptions
{
    /// <summary>
    /// Thrown when courier is not found by ID.
    /// </summary>
    public class CourierNotFoundException : DomainException
    {
        public Guid CourierId { get; }

        public CourierNotFoundException(Guid courierId)
            : base($"Courier with ID {courierId} was not found.")
        {
            CourierId = courierId;
        }
    }
}
