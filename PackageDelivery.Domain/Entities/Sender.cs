using System;
using DeliveryParcel.Domain.Entities.Base;
using DeliveryParcel.Domain.ValueObjects;

namespace DeliveryParcel.Domain.Entities
{
    public class Sender : Entity<Guid>
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; } // Value Object
        public Address Address { get; private set; } // Value Object
        public string Email { get; private set; }

        // Конструктор
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

        // Для EF Core
        protected Sender() : base()
        {
        }

        // Обновление контактной информации
        public void UpdateContactInfo(
            string firstName,
            string lastName,
            PhoneNumber phoneNumber,
            Address address,
            string email)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
            Address = address ?? throw new ArgumentNullException(nameof(address));
            Email = email ?? throw new ArgumentNullException(nameof(email));
        }

        // Изменение только номера телефона и адреса
        public void UpdateBasicContactInfo(PhoneNumber phoneNumber, Address address)
        {
            PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
            Address = address ?? throw new ArgumentNullException(nameof(address));
        }
    }
}
