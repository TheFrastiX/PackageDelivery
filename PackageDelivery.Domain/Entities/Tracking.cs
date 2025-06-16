using System;
using DeliveryParcel.Domain.Entities.Base;
using DeliveryParcel.Domain.Enums;

namespace DeliveryParcel.Domain.Entities
{
    /// <summary>
    /// Представляет запись об отслеживании посылки.
    /// </summary>
    public class Tracking : Entity<Guid>
    {
        public Guid SenderId { get; private set; }
        public Guid RecipientId { get; private set; }
        public Guid OrderId { get; private set; }
        public OrderStatus Status { get; private set; }
        public string Description { get; private set; }
        public DateTime Timestamp { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tracking"/> class.
        /// </summary>
        public Tracking(
            Guid id,
            Guid senderId,
            Guid recipientId,
            Guid orderId,
            OrderStatus status,
            string description)
            : base(id)
        {
            SenderId = senderId;
            RecipientId = recipientId;
            OrderId = orderId;
            Status = status;
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Timestamp = DateTime.UtcNow;
        }

        /// <summary>
        /// Защищённый конструктор для EF Core.
        /// </summary>
        protected Tracking() : base()
        {
        }
    }
}
