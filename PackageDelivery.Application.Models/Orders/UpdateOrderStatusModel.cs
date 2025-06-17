using DeliveryParcel.Domain.Enums;

namespace DeliveryParcel.Application.Models.Orders
{
    public class UpdateOrderStatusModel
    {
        public Guid OrderId { get; set; }
        public int Status { get; set; } // можно заменить на OrderStatus
    }
}
