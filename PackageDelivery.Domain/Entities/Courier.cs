using System;
using DeliveryParcel.Domain.Entities.Base;

namespace DeliveryParcel.Domain.Entities
{
    /// <summary>
    /// Представляет курьера, который доставляет посылки.
    /// </summary>
    public class Courier : Entity<Guid>
    {
        #region Properties

        /// <summary>
        /// Уникальный ID курьера.
        /// </summary>
        public Guid CourierId { get; private set; }

        /// <summary>
        /// Уникальный ID получателя (связь с заказом).
        /// </summary>
        public Guid RecipientId { get; private set; }

        /// <summary>
        /// Номер телефона курьера.
        /// </summary>
        public string PhoneNumber { get; private set; }

        /// <summary>
        /// Адрес отправителя (откуда забирается посылка).
        /// </summary>
        public string SenderAddress { get; private set; }

        /// <summary>
        /// Адрес получателя (куда доставляется посылка).
        /// </summary>
        public string RecipientAddress { get; private set; }

        /// <summary>
        /// Дата и время создания задачи доставки.
        /// </summary>
        public DateTime CreatedAt { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Courier"/> class.
        /// </summary>
        /// <param name="id">Уникальный идентификатор курьера.</param>
        /// <param name="recipientId">ID получателя.</param>
        /// <param name="phoneNumber">Номер телефона курьера.</param>
        /// <param name="senderAddress">Адрес отправителя.</param>
        /// <param name="recipientAddress">Адрес получателя.</param>
        public Courier(
            Guid id,
            Guid recipientId,
            string phoneNumber,
            string senderAddress,
            string recipientAddress)
            : base(id)
        {
            CourierId = id;
            RecipientId = recipientId;
            PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
            SenderAddress = senderAddress ?? throw new ArgumentNullException(nameof(senderAddress));
            RecipientAddress = recipientAddress ?? throw new ArgumentNullException(nameof(recipientAddress));
            CreatedAt = DateTime.UtcNow;
        }

        // Защищённый конструктор для EF Core
        protected Courier() : base()
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Обновляет адреса доставки (например, если получатель изменил адрес).
        /// </summary>
        /// <param name="newSenderAddress">Новый адрес отправителя.</param>
        /// <param name="newRecipientAddress">Новый адрес получателя.</param>
        public void UpdateAddresses(string newSenderAddress, string newRecipientAddress)
        {
            SenderAddress = newSenderAddress ?? throw new ArgumentNullException(nameof(newSenderAddress));
            RecipientAddress = newRecipientAddress ?? throw new ArgumentNullException(nameof(newRecipientAddress));
        }

        /// <summary>
        /// Обновляет номер телефона курьера.
        /// </summary>
        /// <param name="newPhoneNumber">Новый номер телефона.</param>
        public void UpdatePhoneNumber(string newPhoneNumber)
        {
            PhoneNumber = newPhoneNumber ?? throw new ArgumentNullException(nameof(newPhoneNumber));
        }

        #endregion
    }
}
