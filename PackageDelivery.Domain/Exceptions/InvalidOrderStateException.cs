using System;

namespace DeliveryParcel.Domain.Exceptions
{
    /// <summary>
    /// Thrown when an invalid status transition is attempted on an order.
    /// </summary>
    public class InvalidOrderStateException : DomainException
    {
        public int CurrentStatus { get; }
        public int NewStatus { get; }

        public InvalidOrderStateException(int currentStatus, int newStatus)
            : base($"Cannot change status from {currentStatus} to {newStatus}.")
        {
            CurrentStatus = currentStatus;
            NewStatus = newStatus;
        }
    }
}
