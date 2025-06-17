using System;
using DeliveryParcel.Domain.Enums;

namespace DeliveryParcel.Application.Models.Orders
{
    public class OrderDto
    {
        public Guid OrderId { get; set; }
        public Guid SenderId { get; set; }
        public Guid RecipientId { get; set; }
        public Guid? CourierId { get; set; }

        public string SenderAddress { get; set; }
        public string RecipientAddress { get; set; }

        public float WeightKg { get; set; }
        public string Dimensions { get; set; }

        public decimal Price { get; set; }
        public OrderStatus Status { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? DeliveredAt { get; set; }
    }
}
