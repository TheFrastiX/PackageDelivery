using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DeliveryParcel.Domain.Entities;

namespace DeliveryParcel.Domain.Repositories.Abstractions
{
    public interface ITrackingRepository : IRepository<Tracking, Guid>
    {
        Task<IEnumerable<Tracking>> GetByOrderIdAsync(Guid orderId);
        Task AddTrackingEventAsync(Tracking tracking);
    }
}
