using System;
using System.Collections.Generic;
using System.Linq;

namespace DeliveryParcel.Domain.ValueObjects
{
    /// <summary>
    /// Представляет адрес как неизменяемый объект.
    /// </summary>
    public class Address : ValueObject
    {
        public string Street { get; }
        public string City { get; }
        public string PostalCode { get; }
        public string? Apartment { get; }
        public string? Notes { get; }

        /// <summary>
        /// Создает новый экземпляр класса Address.
        /// </summary>
        public Address(
            string street,
            string city,
            string postalCode,
            string? apartment = null,
            string? notes = null)
        {
            if (string.IsNullOrWhiteSpace(street))
                throw new ArgumentNullException(nameof(street));

            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentNullException(nameof(city));

            if (string.IsNullOrWhiteSpace(postalCode))
                throw new ArgumentNullException(nameof(postalCode));

            Street = street;
            City = city;
            PostalCode = postalCode;
            Apartment = apartment;
            Notes = notes;
        }

        /// <summary>
        /// Создает объект Address из строки формата: "город, улица, индекс, кв. 45 (оставить у двери)"
        /// </summary>
        public static Address FromString(string addressString)
        {
            var parts = addressString
                .Split(new[] { ", " }, StringSplitOptions.None)
                .Select(p => p.Trim())
                .ToList();

            if (parts.Count < 3)
                throw new FormatException("Неверный формат адреса. Ожидается минимум: город, улица, индекс");

            string city = parts[0];
            string street = parts[1];
            string postalCode = parts[2];

            string? apartment = null;
            string? notes = null;

            for (int i = 3; i < parts.Count; i++)
            {
                var part = parts[i];

                if (part.StartsWith("кв.") || part.StartsWith("apt.") || part.StartsWith("ап.")) // поддержка нескольких форматов
                {
                    apartment = part.Substring(3).TrimStart(' ', '.');
                }
                else if (part.StartsWith("(") && part.EndsWith(")"))
                {
                    notes = part.TrimStart('(').TrimEnd(')');
                }
                else
                {
                    // если это не квартира или примечание — добавляем к улице
                    street += $", {part}";
                }
            }

            return new Address(
                street: street,
                city: city,
                postalCode: postalCode,
                apartment: apartment,
                notes: notes);
        }

        public string FullAddress => $"{City}, {Street}, {PostalCode}" +
                                   (Apartment != null ? $", кв. {Apartment}" : "") +
                                   (Notes != null ? $" ({Notes})" : "");

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Street;
            yield return City;
            yield return PostalCode;
            yield return Apartment ?? string.Empty;
        }

        public override string ToString() => FullAddress;
    }
}
