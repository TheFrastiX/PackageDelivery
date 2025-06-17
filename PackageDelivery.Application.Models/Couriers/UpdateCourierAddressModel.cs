using System;

namespace DeliveryParcel.Application.Models.Couriers
{
    public class UpdateCourierAddressModel
    {
        public Guid Id { get; set; }
        public string SenderAddress { get; set; }
        public string RecipientAddress { get; set; }
    }
}
