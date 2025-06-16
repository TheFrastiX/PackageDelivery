using System;
using DeliveryParcel.Domain.ValueObjects;
using DeliveryParcel.Domain.Entities.Base;

namespace DeliveryParcel.Domain.Entities
{
    /// <summary>
    /// Представляет курьера, который доставляет посылки.
    /// </summary>
    public class Courier : Entity<Guid>
    {
        public Guid RecipientId { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public string SenderAddress { get; private set; }
        public string RecipientAddress { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Courier"/> class.
        /// </summary>
        public Courier(
            Guid id,
            Guid recipientId,
            PhoneNumber phoneNumber,
            string senderAddress,
            string recipientAddress)
            : base(id)
        {
            RecipientId = recipientId;
            PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
            SenderAddress = senderAddress ?? throw new ArgumentNullException(nameof(senderAddress));
            RecipientAddress = recipientAddress ?? throw new ArgumentNullException(nameof(recipientAddress));
        }

        /// <summary>
        /// Защищённый конструктор для EF Core.
        /// </summary>
        protected Courier() : base()
        {
        }

        /// <summary>
        /// Обновляет адреса доставки.
        /// </summary>
        public void UpdateAddresses(string newSenderAddress, string newRecipientAddress)
        {
            SenderAddress = newSenderAddress ?? throw new ArgumentNullException(nameof(newSenderAddress));
            RecipientAddress = newRecipientAddress ?? throw new ArgumentNullException(nameof(newRecipientAddress));
        }

        /// <summary>
        /// Обновляет номер телефона курьера.
        /// </summary>
        public void UpdatePhoneNumber(PhoneNumber newPhoneNumber)
        {
            PhoneNumber = newPhoneNumber ?? throw new ArgumentNullException(nameof(newPhoneNumber));
        }
    }
}
