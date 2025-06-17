using System.Threading.Tasks;
using DeliveryParcel.Domain.Entities;
using DeliveryParcel.Application.Models.Senders;
using DeliveryParcel.Application.Services.Abstractions;
using DeliveryParcel.Domain.Repositories.Abstractions;

namespace DeliveryParcel.Application.Services.Services
{
    public class SenderService : ISenderService
    {
        private readonly ISenderRepository _senderRepository;

        public SenderService(ISenderRepository senderRepository) =>
            _senderRepository = senderRepository;

        public async Task<Guid> RegisterSenderAsync(CreateSenderModel model)
        {
            var sender = new Sender
            {
                Id = Guid.NewGuid(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber
            };

            await _senderRepository.AddAsync(sender);
            return sender.Id;
        }

        public async Task<SenderDto> GetSenderByIdAsync(Guid id)
        {
            var sender = await _senderRepository.GetByIdAsync(id);
            return new SenderDto
            {
                Id = sender.Id,
                FirstName = sender.FirstName,
                LastName = sender.LastName,
                Email = sender.Email,
                PhoneNumber = sender.PhoneNumber
            };
        }

        public async Task UpdateSenderContactInfoAsync(UpdateSenderModel model)
        {
            var sender = await _senderRepository.GetByIdAsync(model.Id);
            sender.FirstName = model.FirstName;
            sender.LastName = model.LastName;
            sender.Email = model.Email;
            sender.PhoneNumber = model.PhoneNumber;
            await _senderRepository.UpdateAsync(sender);
        }
    }
}
