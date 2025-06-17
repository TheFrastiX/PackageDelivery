using System.Threading.Tasks;
using DeliveryParcel.Application.Models.Recipients;

namespace DeliveryParcel.Application.Services
{
    public interface IRecipientService
    {
        Task<Guid> RegisterRecipientAsync(CreateRecipientModel model);
        Task<RecipientDto> GetRecipientByIdAsync(Guid id);
        Task UpdateRecipientContactInfoAsync(UpdateRecipientModel model);
    }
}
}
