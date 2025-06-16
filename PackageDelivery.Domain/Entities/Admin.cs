using System;
using DeliveryParcel.Domain.Entities.Base;

namespace DeliveryParcel.Domain.Entities
{
    /// <summary>
    /// Представляет администратора системы — пользователя с расширенными правами.
    /// </summary>
    public class Admin : Entity<Guid>
    {
        #region Properties

        /// <summary>
        /// Имя администратора.
        /// </summary>
        public string FirstName { get; private set; }

        /// <summary>
        /// Фамилия администратора.
        /// </summary>
        public string LastName { get; private set; }

        /// <summary>
        /// Электронная почта администратора.
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// Номер телефона администратора.
        /// </summary>
        public string PhoneNumber { get; private set; }

        /// <summary>
        /// Дата регистрации администратора в системе.
        /// </summary>
        public DateTime RegisteredAt { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Admin"/> class.
        /// </summary>
        /// <param name="id">Уникальный идентификатор администратора.</param>
        /// <param name="firstName">Имя администратора.</param>
        /// <param name="lastName">Фамилия администратора.</param>
        /// <param name="email">Электронная почта администратора.</param>
        /// <param name="phoneNumber">Номер телефона администратора.</param>
        public Admin(
            Guid id,
            string firstName,
            string lastName,
            string email,
            string phoneNumber)
            : base(id)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
            RegisteredAt = DateTime.UtcNow;
        }

        // Для EF Core
        protected Admin() : base()
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Обновляет контактную информацию администратора.
        /// </summary>
        /// <param name="firstName">Новое имя.</param>
        /// <param name="lastName">Новая фамилия.</param>
        /// <param name="email">Новый адрес электронной почты.</param>
        /// <param name="phoneNumber">Новый номер телефона.</param>
        public void UpdateContactInfo(
            string firstName,
            string lastName,
            string email,
            string phoneNumber)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
        }

        #endregion
    }
}
