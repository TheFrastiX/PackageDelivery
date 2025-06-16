using System;

namespace DeliveryParcel.Domain.Exceptions
{
    /// <summary>
    /// Thrown when a courier cannot be assigned to an order.
    /// </summary>
    public class InvalidCourierAssignmentException : DomainException
    {
        public Guid OrderId { get; }
        public Guid CourierId { get; }

        public InvalidCourierAssignmentException(Guid orderId, Guid courierId, string reason)
            : base($"Failed to assign courier {courierId} to order {orderId}. Reason: {reason}")
        {
            OrderId = orderId;
            CourierId = courierId;
        }
    }
}
