using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DeliveryParcel.Domain.Entities;

namespace DeliveryParcel.Domain.Repositories.Abstractions
{
    public interface IOrderRepository : IRepository<Order, Guid>
    {
        Task<IEnumerable<Order>> GetBySenderIdAsync(Guid senderId);
        Task<IEnumerable<Order>> GetByRecipientIdAsync(Guid recipientId);
        Task<IEnumerable<Order>> GetByCourierIdAsync(Guid courierId);
        Task<IEnumerable<Order>> GetByStatusAsync(int status);
        Task UpdateStatusAsync(Guid orderId, int newStatus);
    }
}
