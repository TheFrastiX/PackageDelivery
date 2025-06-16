using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DeliveryParcel.Domain.Entities;

namespace DeliveryParcel.Domain.Repositories.Abstractions
{
    public interface IRecipientRepository : IRepository<Recipient, Guid>
    {
        Task<Recipient?> GetByEmailAsync(string email);
        Task<Recipient?> GetByPhoneAsync(int phoneNumber);
        Task<IEnumerable<Recipient>> GetBySenderIdAsync(Guid senderId);
        Task UpdateContactInfoAsync(Recipient recipient);
    }
}
