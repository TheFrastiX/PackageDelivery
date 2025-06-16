using System;
using System.Collections.Generic;
using System.Linq;
using DeliveryParcel.Domain.ValueObjects;
using DeliveryParcel.Domain.Entities.Base;
using DeliveryParcel.Domain.Enums;

namespace DeliveryParcel.Domain.Entities
{
    /// <summary>
    /// Представляет заказ на доставку посылки.
    /// </summary>
    public class Order : Entity<Guid>
    {
        public Guid SenderId { get; private set; }
        public Guid RecipientId { get; private set; }
        public Guid? CourierId { get; private set; }
        public Address SenderAddress { get; private set; }
        public Address RecipientAddress { get; private set; }
        public Weight Weight { get; private set; }
        public string Dimensions { get; private set; }
        public decimal Price { get; private set; }
        public OrderStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? DeliveredAt { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/> class.
        /// </summary>
        public Order(
            Guid id,
            Guid senderId,
            Guid recipientId,
            Address senderAddress,
            Address recipientAddress,
            Weight weight,
            string dimensions,
            decimal price)
            : base(id)
        {
            SenderId = senderId;
            RecipientId = recipientId;
            SenderAddress = senderAddress ?? throw new ArgumentNullException(nameof(senderAddress));
            RecipientAddress = recipientAddress ?? throw new ArgumentNullException(nameof(recipientAddress));
            Weight = weight ?? throw new ArgumentNullException(nameof(weight));
            Dimensions = dimensions ?? throw new ArgumentNullException(nameof(dimensions));
            Price = price;
            Status = OrderStatus.Created;
            CreatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Защищённый конструктор для EF Core.
        /// </summary>
        protected Order() : base()
        {
        }

        /// <summary>
        /// Назначает курьера для заказа.
        /// </summary>
        public void AssignCourier(Guid courierId)
        {
            CourierId = courierId;
        }

        /// <summary>
        /// Обновляет статус заказа.
        /// </summary>
        public void UpdateStatus(OrderStatus newStatus)
        {
            if (!Enum.IsDefined(typeof(OrderStatus), newStatus))
                throw new ArgumentException("Invalid order status.");

            Status = newStatus;

            if (newStatus == OrderStatus.Delivered)
                DeliveredAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Обновляет адреса доставки.
        /// </summary>
        public void UpdateAddresses(Address newSenderAddress, Address newRecipientAddress)
        {
            SenderAddress = newSenderAddress ?? throw new ArgumentNullException(nameof(newSenderAddress));
            RecipientAddress = newRecipientAddress ?? throw new ArgumentNullException(nameof(newRecipientAddress));
        }

        /// <summary>
        /// Обновляет вес и габариты посылки.
        /// </summary>
        public void UpdateParcelDetails(Weight newWeight, string newDimensions)
        {
            Weight = newWeight ?? throw new ArgumentNullException(nameof(newWeight));
            Dimensions = newDimensions ?? throw new ArgumentNullException(nameof(newDimensions));
        }
    }
}
