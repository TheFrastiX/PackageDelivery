using DeliveryParcel.Domain.ValueObjects;
using DeliveryParcel.Domain.Entities.Base;

namespace DeliveryParcel.Domain.Entities
{
    /// <summary>
    /// Представляет пользователя системы, который может отправлять посылки.
    /// </summary>
    public class Sender : Entity<Guid>
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public Address Address { get; private set; }
        public string Email { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Sender"/> class.
        /// </summary>
        public Sender(
            Guid id,
            string firstName,
            string lastName,
            PhoneNumber phoneNumber,
            Address address,
            string email)
            : base(id)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
            Address = address ?? throw new ArgumentNullException(nameof(address));
            Email = email ?? throw new ArgumentNullException(nameof(email));
        }

        /// <summary>
        /// Защищённый конструктор для EF Core.
        /// </summary>
        protected Sender() : base()
        {
        }

        /// <summary>
        /// Обновляет контактную информацию отправителя.
        /// </summary>
        public void UpdateContactInfo(PhoneNumber phoneNumber, Address address, string email)
        {
            PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
            Address = address ?? throw new ArgumentNullException(nameof(address));
            Email = email ?? throw new ArgumentNullException(nameof(email));
        }
    }
}
