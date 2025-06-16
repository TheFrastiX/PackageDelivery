using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DeliveryParcel.Domain.ValueObjects
{
    public class Dimensions : ValueObject
    {
        private const string DimensionPattern = @"^\d+[xX]\d+[xX]\d+$";

        public string Value { get; }

        public Dimensions(string value)
        {
            if (!Regex.IsMatch(value, DimensionPattern))
                throw new ArgumentException("Некорректный формат габаритов. Пример: 30x40x50", nameof(value));

            Value = value.ToUpper();
        }

        public static Dimensions FromString(string value)
        {
            return new Dimensions(value);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public override string ToString() => Value;
    }
}
