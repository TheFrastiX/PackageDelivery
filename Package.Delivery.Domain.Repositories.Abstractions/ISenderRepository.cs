using System;
using System.Threading.Tasks;
using DeliveryParcel.Domain.Entities;

namespace DeliveryParcel.Domain.Repositories.Abstractions
{
    public interface ISenderRepository : IRepository<Sender, Guid>
    {
        Task<Sender?> GetByEmailAsync(string email);
        Task<Sender?> GetByPhoneAsync(int phoneNumber);
        Task<bool> ExistsWithEmailAsync(string email);
        Task UpdateContactInfoAsync(Sender sender);
    }
}
