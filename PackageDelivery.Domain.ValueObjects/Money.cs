using System;
using System.Collections.Generic;

namespace DeliveryParcel.Domain.ValueObjects
{
    public class Money : ValueObject
    {
        public decimal Amount { get; }

        public Money(decimal amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Сумма не может быть отрицательной.");

            Amount = amount;
        }

        public static Money FromDecimal(decimal amount)
        {
            return new Money(amount);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;
        }

        public override string ToString() => $"{Amount:F2} ₽";
    }
}
