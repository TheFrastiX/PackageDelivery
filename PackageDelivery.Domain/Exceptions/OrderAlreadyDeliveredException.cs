using System;

namespace DeliveryParcel.Domain.Exceptions
{
    /// <summary>
    /// Thrown when trying to deliver an already delivered order.
    /// </summary>
    public class OrderAlreadyDeliveredException : DomainException
    {
        public Guid OrderId { get; }

        public OrderAlreadyDeliveredException(Guid orderId)
            : base($"Order with ID {orderId} has already been delivered.")
        {
            OrderId = orderId;
        }
    }
}
