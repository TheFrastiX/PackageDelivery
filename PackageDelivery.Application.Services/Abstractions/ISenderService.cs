using System.Threading.Tasks;
using DeliveryParcel.Application.Models.Senders;

namespace DeliveryParcel.Application.Services.Abstractions
{
    public interface ISenderService
    {
        Task<Guid> RegisterSenderAsync(CreateSenderModel model);
        Task<SenderDto> GetSenderByIdAsync(Guid id);
        Task UpdateSenderContactInfoAsync(UpdateSenderModel model);
    }
}
