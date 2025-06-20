using System.Collections.Generic;
using System.Threading.Tasks;
using DeliveryParcel.Application.Models.Couriers;

namespace DeliveryParcel.Application.Services.Abstractions
{
    public interface ICourierService
    {
        Task<Guid> AssignNewCourierTaskAsync(CreateCourierModel model);
        Task<CourierDto> GetCourierByIdAsync(Guid id);
        Task UpdateCourierAddressesAsync(UpdateCourierAddressModel model);
        Task<IEnumerable<CourierDto>> GetAllAvailableCouriersAsync();
    }
}
