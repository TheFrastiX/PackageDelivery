using System.Collections.Generic;
using System.Threading.Tasks;
using DeliveryParcel.Application.Models.Tracking;

namespace DeliveryParcel.Application.Services.Abstractions
{
    public interface ITrackingService
    {
        Task<Guid> AddTrackingEventAsync(CreateTrackingEventModel model);
        Task<IEnumerable<TrackingEventDto>> GetTrackingEventsByOrderIdAsync(Guid orderId);
    }
}
