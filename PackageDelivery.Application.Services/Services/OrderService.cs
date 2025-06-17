using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DeliveryParcel.Application.Models.Orders;
using DeliveryParcel.Domain.Entities;
using DeliveryParcel.Domain.Repositories.Abstractions;
using DeliveryParcel.Domain.Exceptions;

namespace DeliveryParcel.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository) =>
            _orderRepository = orderRepository;

        public async Task<Guid> CreateOrderAsync(CreateOrderModel model)
        {
            var order = new Order(
                id: Guid.NewGuid(),
                senderId: model.SenderId,
                recipientId: model.RecipientId,
                senderAddress: model.SenderAddress,
                recipientAddress: model.RecipientAddress,
                weightKg: model.WeightKg,
                dimensions: model.Dimensions,
                price: model.Price);

            await _orderRepository.AddAsync(order);
            return order.OrderId;
        }

        public async Task<OrderDto> GetOrderByIdAsync(Guid id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
                throw new OrderNotFoundException(id);

            return MapToDto(order);
        }

        public async Task UpdateOrderStatusAsync(UpdateOrderStatusModel model)
        {
            var order = await _orderRepository.GetByIdAsync(model.OrderId);
            if (order == null)
                throw new OrderNotFoundException(model.OrderId);

            if (order.Status is 4 or 5) // Delivered / Failed
                throw new CannotCancelCompletedOrderException(model.OrderId, order.Status);

            order.UpdateStatus(model.Status);
            await _orderRepository.UpdateAsync(order);
        }

        public async Task<IEnumerable<OrderDto>> GetOrdersBySenderIdAsync(Guid senderId)
        {
            var orders = await _orderRepository.GetBySenderIdAsync(senderId);
            return orders.Select(MapToDto).ToList();
        }

        public async Task<IEnumerable<OrderDto>> GetOrdersByCourierIdAsync(Guid courierId)
        {
            var orders = await _orderRepository.GetByCourierIdAsync(courierId);
            return orders.Select(MapToDto).ToList();
        }

        private OrderDto MapToDto(Order order)
        {
            return new OrderDto
            {
                OrderId = order.OrderId,
                SenderId = order.SenderId,
                RecipientId = order.RecipientId,
                CourierId = order.CourierId,
                SenderAddress = order.SenderAddress,
                RecipientAddress = order.RecipientAddress,
                WeightKg = order.WeightKg,
                Dimensions = order.Dimensions,
                Price = order.Price,
                Status = order.Status,
                CreatedAt = order.CreatedAt,
                DeliveredAt = order.DeliveredAt
            };
        }
    }
}
