using System;

namespace DeliveryParcel.Domain.Exceptions
{
    /// <summary>
    /// Thrown when parcel data is invalid.
    /// </summary>
    public class InvalidParcelDataException : DomainException
    {
        public string FieldName { get; }

        public InvalidParcelDataException(string fieldName, string message)
            : base(message)
        {
            FieldName = fieldName;
        }

        public InvalidParcelDataException(string fieldName, string message, Exception innerException)
            : base(message, innerException)
        {
            FieldName = fieldName;
        }
    }
}
