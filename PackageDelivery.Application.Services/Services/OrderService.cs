using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DeliveryParcel.Domain.Entities;
using DeliveryParcel.Application.Models.Orders;
using DeliveryParcel.Application.Services.Abstractions;
using DeliveryParcel.Domain.Repositories.Abstractions;
using DeliveryParcel.Domain.Exceptions;

namespace DeliveryParcel.Application.Services.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository) =>
            _orderRepository = orderRepository;

        public async Task<Guid> CreateOrderAsync(CreateOrderModel model)
        {
            var order = new Order
            {
                Id = Guid.NewGuid(),
                SenderId = model.SenderId,
                RecipientId = model.RecipientId,
                SenderAddress = model.SenderAddress,
                RecipientAddress = model.RecipientAddress,
                WeightKg = model.WeightKg,
                Dimensions = model.Dimensions,
                Price = model.Price,
                Status = 0, // Created
                CreatedAt = DateTime.UtcNow
            };

            await _orderRepository.AddAsync(order);
            return order.Id;
        }

        public async Task<OrderDto> GetOrderByIdAsync(Guid id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
                throw new OrderNotFoundException(id);

            return new OrderDto
            {
                OrderId = order.Id,
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

        public async Task UpdateOrderStatusAsync(UpdateOrderStatusModel model)
        {
            var order = await _orderRepository.GetByIdAsync(model.OrderId);
            if (order == null)
                throw new OrderNotFoundException(model.OrderId);

            if (order.Status is 4 or 5)
                throw new CannotCancelCompletedOrderException(model.OrderId, order.Status);

            order.Status = model.Status;
            await _orderRepository.UpdateAsync(order);
        }

        public async Task<IEnumerable<OrderDto>> GetOrdersBySenderIdAsync(Guid senderId)
        {
            var orders = await _orderRepository.GetBySenderIdAsync(senderId);
            return orders.Select(o => new OrderDto
            {
                OrderId = o.Id,
                SenderId = o.SenderId,
                RecipientId = o.RecipientId,
                CourierId = o.CourierId,
                SenderAddress = o.SenderAddress,
                RecipientAddress = o.RecipientAddress,
                WeightKg = o.WeightKg,
                Dimensions = o.Dimensions,
                Price = o.Price,
                Status = o.Status,
                CreatedAt = o.CreatedAt,
                DeliveredAt = o.DeliveredAt
            });
        }

        public async Task<IEnumerable<OrderDto>> GetOrdersByCourierIdAsync(Guid courierId)
        {
            var orders = await _orderRepository.GetByCourierIdAsync(courierId);
            return orders.Select(o => new OrderDto
            {
                OrderId = o.Id,
                SenderId = o.SenderId,
                RecipientId = o.RecipientId,
                CourierId = o.CourierId,
                SenderAddress = o.SenderAddress,
                RecipientAddress = o.RecipientAddress,
                WeightKg = o.WeightKg,
                Dimensions = o.Dimensions,
                Price = o.Price,
                Status = o.Status,
                CreatedAt = o.CreatedAt,
                DeliveredAt = o.DeliveredAt
            });
        }
    }
}
