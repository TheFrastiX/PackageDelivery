using System.Threading.Tasks;
using DeliveryParcel.Application.Models.Couriers;
using DeliveryParcel.Domain.Entities;
using DeliveryParcel.Domain.Repositories.Abstractions;

namespace DeliveryParcel.Application.Services
{
    public class CourierService : ICourierService
    {
        private readonly ICourierRepository _courierRepository;

        public CourierService(ICourierRepository courierRepository) =>
            _courierRepository = courierRepository;

        public async Task<Guid> AssignNewCourierTaskAsync(CreateCourierModel model)
        {
            var courier = new Courier
            {
                Id = Guid.NewGuid(),
                RecipientId = model.RecipientId,
                PhoneNumber = model.PhoneNumber,
                SenderAddress = model.SenderAddress,
                RecipientAddress = model.RecipientAddress,
                CreatedAt = DateTime.UtcNow
            };

            await _courierRepository.AddAsync(courier);
            return courier.Id;
        }

        public async Task<CourierDto> GetCourierByIdAsync(Guid id)
        {
            var courier = await _courierRepository.GetByIdAsync(id);
            return new CourierDto
            {
                Id = courier.Id,
                RecipientId = courier.RecipientId,
                PhoneNumber = courier.PhoneNumber,
                SenderAddress = courier.SenderAddress,
                RecipientAddress = courier.RecipientAddress,
                CreatedAt = courier.CreatedAt
            };
        }

        public async Task UpdateCourierAddressesAsync(UpdateCourierAddressModel model)
        {
            var courier = await _courierRepository.GetByIdAsync(model.Id);
            courier.SenderAddress = model.SenderAddress;
            courier.RecipientAddress = model.RecipientAddress;
            await _courierRepository.UpdateAsync(courier);
        }

        public async Task<IEnumerable<CourierDto>> GetAllAvailableCouriersAsync()
        {
            var couriers = await _courierRepository.GetAllAsync();
            return couriers.Select(c => new CourierDto
            {
                Id = c.Id,
                RecipientId = c.RecipientId,
                PhoneNumber = c.PhoneNumber,
                SenderAddress = c.SenderAddress,
                RecipientAddress = c.RecipientAddress,
                CreatedAt = c.CreatedAt
            });
        }
    }
}
