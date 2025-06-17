using System;

namespace DeliveryParcel.Application.Models.Tracking
{
    public class CreateTrackingEventModel
    {
        public Guid OrderId { get; set; }
        public Guid SenderId { get; set; }
        public Guid RecipientId { get; set; }
        public int Status { get; set; }
        public string Description { get; set; }
    }
}
