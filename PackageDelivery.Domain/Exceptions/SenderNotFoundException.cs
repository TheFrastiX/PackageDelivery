using System;

namespace DeliveryParcel.Domain.Exceptions
{
    /// <summary>
    /// Thrown when sender is not found by ID.
    /// </summary>
    public class SenderNotFoundException : DomainException
    {
        public Guid SenderId { get; }

        public SenderNotFoundException(Guid senderId)
            : base($"Sender with ID {senderId} was not found.")
        {
            SenderId = senderId;
        }
    }
}
