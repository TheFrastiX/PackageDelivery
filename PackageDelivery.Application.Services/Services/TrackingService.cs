using System.Collections.Generic;
using System.Threading.Tasks;
using DeliveryParcel.Domain.Entities;
using DeliveryParcel.Application.Models.Tracking;
using DeliveryParcel.Application.Services.Abstractions;
using DeliveryParcel.Domain.Repositories.Abstractions;

namespace DeliveryParcel.Application.Services.Services
{
    public class TrackingService : ITrackingService
    {
        private readonly ITrackingRepository _trackingRepository;

        public TrackingService(ITrackingRepository trackingRepository) =>
            _trackingRepository = trackingRepository;

        public async Task<Guid> AddTrackingEventAsync(CreateTrackingEventModel model)
        {
            var tracking = new Tracking
            {
                Id = Guid.NewGuid(),
                SenderId = model.SenderId,
                RecipientId = model.RecipientId,
                OrderId = model.OrderId,
                Status = model.Status,
                Description = model.Description
            };

            await _trackingRepository.AddAsync(tracking);
            return tracking.Id;
        }

        public async Task<IEnumerable<TrackingEventDto>> GetTrackingEventsByOrderIdAsync(Guid orderId)
        {
            var events = await _trackingRepository.GetByOrderIdAsync(orderId);
            return events.Select(e => new TrackingEventDto
            {
                Id = e.Id,
                OrderId = e.OrderId,
                SenderId = e.SenderId,
                RecipientId = e.RecipientId,
                Status = e.Status,
                Description = e.Description,
                Timestamp = e.Timestamp
            }).ToList();
        }
    }
}
