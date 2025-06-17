using System;

namespace DeliveryParcel.Application.Models.Couriers
{
    public class CreateCourierModel
    {
        public Guid RecipientId { get; set; }
        public int PhoneNumber { get; set; }
        public string SenderAddress { get; set; }
        public string RecipientAddress { get; set; }
    }
}
