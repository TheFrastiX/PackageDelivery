using System;

namespace DeliveryParcel.Domain.Exceptions
{
    /// <summary>
    /// Thrown when the order is not found.
    /// </summary>
    public class OrderNotFoundException : DomainException
    {
        public Guid OrderId { get; }

        public OrderNotFoundException(Guid orderId)
            : base($"Order with ID {orderId} was not found.")
        {
            OrderId = orderId;
        }
    }
}
