using System;

namespace DeliveryParcel.Application.Models.Orders
{
    public class CreateOrderModel
    {
        public Guid SenderId { get; set; }
        public Guid RecipientId { get; set; }

        public string SenderAddress { get; set; }
        public string RecipientAddress { get; set; }

        public float WeightKg { get; set; }
        public string Dimensions { get; set; }
        public decimal Price { get; set; }
    }
}
