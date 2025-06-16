using System;
using System.Collections.Generic;
using System.Linq;
using DeliveryParcel.Domain.Enums;
using DeliveryParcel.Domain.Entities.Base;

namespace DeliveryParcel.Domain.Entities
{
    /// <summary>
    /// Represents a parcel order in the delivery system.
    /// </summary>
    public class Order : Entity<Guid>
    {
        #region Properties

        /// <summary>
        /// Gets the ID of the sender.
        /// </summary>
        public Guid SenderId { get; private set; }

        /// <summary>
        /// Gets the ID of the recipient.
        /// </summary>
        public Guid RecipientId { get; private set; }

        /// <summary>
        /// Gets the optional ID of the assigned courier.
        /// </summary>
        public Guid? CourierId { get; private set; }

        /// <summary>
        /// Gets the address of the sender.
        /// </summary>
        public string SenderAddress { get; private set; }

        /// <summary>
        /// Gets the address of the recipient.
        /// </summary>
        public string RecipientAddress { get; private set; }

        /// <summary>
        /// Gets the weight of the parcel in kilograms.
        /// </summary>
        public float WeightKg { get; private set; }

        /// <summary>
        /// Gets the dimensions of the parcel (e.g., "30x40x50").
        /// </summary>
        public string Dimensions { get; private set; }

        /// <summary>
        /// Gets the calculated or specified price of delivery.
        /// </summary>
        public decimal Price { get; private set; }

        /// <summary>
        /// Gets the current status of the order (e.g., Created, InTransit, Delivered).
        /// </summary>
        public OrderStatus Status { get; private set; }

        /// <summary>
        /// Gets the date and time when the order was created.
        /// </summary>
        public DateTime CreatedAt { get; private set; }

        /// <summary>
        /// Gets the optional date and time when the order was delivered.
        /// </summary>
        public DateTime? DeliveredAt { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/> class.
        /// </summary>
        /// <param name="id">The unique identifier for the order.</param>
        /// <param name="senderId">The ID of the sender.</param>
        /// <param name="recipientId">The ID of the recipient.</param>
        /// <param name="senderAddress">The address of the sender.</param>
        /// <param name="recipientAddress">The address of the recipient.</param>
        /// <param name="weightKg">The weight of the parcel in kilograms.</param>
        /// <param name="dimensions">The dimensions of the parcel (e.g., "30x40x50").</param>
        /// <param name="price">The calculated or specified price of delivery.</param>
        public Order(
            Guid id,
            Guid senderId,
            Guid recipientId,
            string senderAddress,
            string recipientAddress,
            float weightKg,
            string dimensions,
            decimal price)
            : base(id)
        {
            SenderId = senderId;
            RecipientId = recipientId;
            SenderAddress = senderAddress ?? throw new ArgumentNullException(nameof(senderAddress));
            RecipientAddress = recipientAddress ?? throw new ArgumentNullException(nameof(recipientAddress));
            WeightKg = weightKg;
            Dimensions = dimensions ?? throw new ArgumentNullException(nameof(dimensions));
            Price = price;
            Status = OrderStatus.Created;
            CreatedAt = DateTime.UtcNow;
            CourierId = null;
            DeliveredAt = null;
        }

        // For EF Core
        protected Order() : base()
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Assigns a courier to this order.
        /// </summary>
        /// <param name="courierId">The ID of the courier.</param>
        public void AssignCourier(Guid courierId)
        {
            CourierId = courierId;
        }

        /// <summary>
        /// Updates the status of the order.
        /// </summary>
        /// <param name="newStatus">The new status of the order.</param>
        public void UpdateStatus(OrderStatus newStatus)
        {
            if (!Enum.IsDefined(typeof(OrderStatus), newStatus))
                throw new ArgumentException("Invalid order status.", nameof(newStatus));

            if (Status == newStatus)
                return;

            Status = newStatus;

            if (newStatus == OrderStatus.Delivered)
                DeliveredAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Updates the delivery price.
        /// </summary>
        /// <param name="newPrice">The new delivery price.</param>
        public void UpdatePrice(decimal newPrice)
        {
            if (newPrice <= 0)
                throw new ArgumentOutOfRangeException(nameof(newPrice), "Price must be greater than zero.");

            Price = newPrice;
        }

        /// <summary>
        /// Updates the addresses of the sender and recipient.
        /// </summary>
        /// <param name="senderAddress">New sender address.</param>
        /// <param name="recipientAddress">New recipient address.</param>
        public void UpdateAddresses(string senderAddress, string recipientAddress)
        {
            SenderAddress = senderAddress ?? throw new ArgumentNullException(nameof(senderAddress));
            RecipientAddress = recipientAddress ?? throw new ArgumentNullException(nameof(recipientAddress));
        }

        /// <summary>
        /// Updates the parcel details (weight and dimensions).
        /// </summary>
        /// <param name="weightKg">Weight in kilograms.</param>
        /// <param name="dimensions">Dimensions like "30x40x50".</param>
        public void UpdateParcelDetails(float weightKg, string dimensions)
        {
            if (weightKg <= 0)
                throw new ArgumentOutOfRangeException(nameof(weightKg), "Weight must be greater than zero.");

            if (string.IsNullOrWhiteSpace(dimensions))
                throw new ArgumentNullException(nameof(dimensions));

            WeightKg = weightKg;
            Dimensions = dimensions;
        }

        #endregion
    }
}
