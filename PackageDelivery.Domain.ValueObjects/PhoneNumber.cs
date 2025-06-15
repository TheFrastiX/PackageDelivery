namespace DeliveryParcel.Domain.ValueObjects
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Represents a phone number as an immutable value object.
    /// </summary>
    public class PhoneNumber 
    {
        /// <summary>
        /// The phone number value.
        /// </summary>
        public string Number { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PhoneNumber"/> class.
        /// </summary>
        /// <param name="number">The phone number string.</param>
        public PhoneNumber(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
                throw new ArgumentException("Phone number cannot be empty.", nameof(number));

            // Basic validation for common phone number formats:
            // Allows optional leading '+', digits, spaces, dashes, parentheses
            if (!Regex.IsMatch(number, @"^\+?[0-9\s\-()]{7,}$"))
                throw new ArgumentException("Invalid phone number format.", nameof(number));

            Number = number;
        }

        /// <summary>
        /// Creates a phone number from a string input.
        /// </summary>
        /// <param name="number">The phone number string.</param>
        /// <returns>A valid PhoneNumber instance.</returns>
        public static PhoneNumber FromString(string number)
        {
            return new PhoneNumber(number);
        }

        /// <summary>
        /// Implicit conversion to string for easier usage.
        /// </summary>
        public static implicit operator string(PhoneNumber phoneNumber) => phoneNumber.Number;

        /// <summary>
        /// Returns the phone number as a string.
        /// </summary>
        public override string ToString() => Number;
    }
}
