using System;
using System.Collections.Generic;
using System.Linq;
using DeliveryParcel.Domain.Entities.Base;

namespace DeliveryParcel.Domain.Entities
{
    /// <summary>
    /// Представляет получателя посылки в системе доставки.
    /// </summary>
    public class Recipient : Entity<Guid>
    {
        #region Properties

        /// <summary>
        /// Имя получателя.
        /// </summary>
        public string FirstName { get; private set; }

        /// <summary>
        /// Фамилия получателя.
        /// </summary>
        public string LastName { get; private set; }

        /// <summary>
        /// Номер телефона получателя.
        /// </summary>
        public string PhoneNumber { get; private set; }

        /// <summary>
        /// Электронная почта получателя.
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// Уникальный ID отправителя (для связи).
        /// </summary>
        public Guid SenderId { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Recipient"/> class.
        /// </summary>
        /// <param name="id">Уникальный идентификатор получателя.</param>
        /// <param name="firstName">Имя получателя.</param>
        /// <param name="lastName">Фамилия получателя.</param>
        /// <param name="phoneNumber">Номер телефона получателя.</param>
        /// <param name="email">Электронная почта получателя.</param>
        /// <param name="senderId">Уникальный ID отправителя.</param>
        public Recipient(
            Guid id,
            string firstName,
            string lastName,
            string phoneNumber,
            string email,
            Guid senderId)
            : base(id)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            SenderId = senderId;
        }

        // Для EF Core
        protected Recipient() : base()
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Обновляет контактную информацию получателя.
        /// </summary>
        /// <param name="firstName">Новое имя.</param>
        /// <param name="lastName">Новая фамилия.</param>
        /// <param name="phoneNumber">Новый номер телефона.</param>
        /// <param name="email">Новый адрес электронной почты.</param>
        public void UpdateContactInfo(
            string firstName,
            string lastName,
            string phoneNumber,
            string email)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
            Email = email ?? throw new ArgumentNullException(nameof(email));
        }

        /// <summary>
        /// Обновляет только номер телефона и адрес электронной почты.
        /// </summary>
        /// <param name="phoneNumber">Новый номер телефона.</param>
        /// <param name="email">Новый адрес электронной почты.</param>
        public void UpdateBasicContactInfo(string phoneNumber, string email)
        {
            PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
            Email = email ?? throw new ArgumentNullException(nameof(email));
        }

        #endregion
    }
}
