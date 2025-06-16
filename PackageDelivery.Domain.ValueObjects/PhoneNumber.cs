using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace DeliveryParcel.Domain.ValueObjects
{
    public class PhoneNumber : ValueObject
    {
        private const string PhonePattern = @"^\+?[0-9\s\-()]{7,}$";

        public string Number { get; }

        public PhoneNumber(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
                throw new ArgumentNullException(nameof(number));

            if (!Regex.IsMatch(number, PhonePattern))
                throw new ArgumentException("Некорректный номер телефона", nameof(number));

            Number = number;
        }

        public static PhoneNumber FromString(string number)
        {
            return new PhoneNumber(number);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Number;
        }

        public override string ToString() => Number;
    }
}
