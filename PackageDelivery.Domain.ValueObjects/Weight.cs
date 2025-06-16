using System;
using System.Collections.Generic;

namespace DeliveryParcel.Domain.ValueObjects
{
    public class Weight : ValueObject
    {
        public decimal Kilograms { get; }

        public Weight(decimal kilograms)
        {
            if (kilograms <= 0)
                throw new ArgumentOutOfRangeException(nameof(kilograms), "Вес должен быть больше нуля.");

            Kilograms = kilograms;
        }

        public static Weight FromKilograms(decimal kg)
        {
            return new Weight(kg);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Kilograms;
        }

        public override string ToString() => $"{Kilograms} кг";
    }
}
