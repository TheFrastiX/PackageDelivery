using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DeliveryParcel.Domain.Entities;

namespace DeliveryParcel.Domain.Repositories.Abstractions
{
    public interface ICourierRepository : IRepository<Courier, Guid>
    {
        Task<Courier?> GetByPhoneAsync(int phoneNumber);
        Task<IEnumerable<Courier>> GetAvailableCouriersAsync();
        Task UpdateAddressesAsync(Courier courier);
    }
}
