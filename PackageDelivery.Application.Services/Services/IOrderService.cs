using System.Threading.Tasks;
using DeliveryParcel.Application.Models.Orders;

namespace DeliveryParcel.Application.Services
{
    public interface IOrderService
    {
        Task<Guid> CreateOrderAsync(CreateOrderModel model);
        Task<OrderDto> GetOrderByIdAsync(Guid id);
        Task UpdateOrderStatusAsync(UpdateOrderStatusModel model);
        Task<IEnumerable<OrderDto>> GetOrdersBySenderIdAsync(Guid senderId);
        Task<IEnumerable<OrderDto>> GetOrdersByCourierIdAsync(Guid courierId);
    }
}
