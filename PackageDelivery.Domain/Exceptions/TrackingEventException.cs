using System;

namespace DeliveryParcel.Domain.Exceptions
{
    /// <summary>
    /// Thrown when there is an error creating or updating a tracking event.
    /// </summary>
    public class TrackingEventException : DomainException
    {
        public Guid OrderId { get; }

        public TrackingEventException(Guid orderId, string reason)
            : base($"Error occurred while tracking order {orderId}. Reason: {reason}")
        {
            OrderId = orderId;
        }

        public TrackingEventException(Guid orderId, string reason, Exception innerException)
            : base($"Error occurred while tracking order {orderId}. Reason: {reason}", innerException)
        {
            OrderId = orderId;
        }
    }
}
