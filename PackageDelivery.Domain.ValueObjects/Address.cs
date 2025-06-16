using System;
using System.Collections.Generic;
using System.Linq;

namespace DeliveryParcel.Domain.ValueObjects
{
    public class Address 
    {

        public string City { get; }
        public string Street { get; }
        public string PostalCode { get; }
        public string? Apartment { get; }
        public string? Notes { get; }
        public Address(
            string city,
            string street,
            string postalCode,
            string? apartment = null,
            string? notes = null)
        {
            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentException("City is required.", nameof(city));

            if (string.IsNullOrWhiteSpace(street))
                throw new ArgumentException("Street is required.", nameof(street));

            if (string.IsNullOrWhiteSpace(postalCode))
                throw new ArgumentException("Postal code is required.", nameof(postalCode));

            City = city;
            Street = street;
            PostalCode = postalCode;
            Apartment = apartment;
            Notes = notes;
        }


        public static Address FromString(string addressString)
        {
            var parts = addressString.Split(new[] { ", " }, StringSplitOptions.None);

            if (parts.Length < 3)
                throw new ArgumentException("Invalid address format. Expected at least city, street and postal code.");

            string city = parts[0].Trim();
            string street = parts[1].Trim();
            string postalCode = parts[2].Trim();

            string? apartment = null;
            string? notes = null;

            for (int i = 3; i < parts.Length; i++)
            {
                var part = parts[i].Trim();

                if (part.StartsWith("кв.") || part.StartsWith("apt.") || part.StartsWith("ап.")) // Поддержка разных форматов
                {
                    apartment = part.Substring(3).TrimStart(' ', '.');
                }
                else if (part.StartsWith("(") && part.EndsWith(")"))
                {
                    notes = part.TrimStart('(').TrimEnd(')');
                }
                else
                {
                    // Если это не квартира или заметка — добавляем к адресу
                    street += $", {part}";
                }
            }

            return new Address(
                city: city,
                street: street,
                postalCode: postalCode,
                apartment: apartment,
                notes: notes);
        }

        public string FullAddress => $"{City}, {Street}, {PostalCode}" +
                                   (Apartment != null ? $", кв. {Apartment}" : "") +
                                   (Notes != null ? $" ({Notes})" : "");


        protected virtual IEnumerable<object> GetEqualityComponents()
        {
            yield return City;
            yield return Street;
            yield return PostalCode;
            yield return Apartment ?? string.Empty;
        }


        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != GetType())
                return false;

            var other = (Address)obj;

            return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }


        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                foreach (var component in GetEqualityComponents())
                {
                    hash = hash * 23 + component?.GetHashCode() ?? 0;
                }
                return hash;
            }
        }

        public override string ToString() => FullAddress;
    }
}
