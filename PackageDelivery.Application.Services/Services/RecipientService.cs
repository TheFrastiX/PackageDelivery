using System.Threading.Tasks;
using DeliveryParcel.Application.Models.Recipients;
using DeliveryParcel.Domain.Entities;
using DeliveryParcel.Domain.Repositories.Abstractions;

namespace DeliveryParcel.Application.Services
{
    public class RecipientService : IRecipientService
    {
        private readonly IRecipientRepository _recipientRepository;

        public RecipientService(IRecipientRepository recipientRepository) =>
            _recipientRepository = recipientRepository;

        public async Task<Guid> RegisterRecipientAsync(CreateRecipientModel model)
        {
            var recipient = new Recipient
            {
                Id = Guid.NewGuid(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                SenderId = model.SenderId
            };

            await _recipientRepository.AddAsync(recipient);
            return recipient.Id;
        }

        public async Task<RecipientDto> GetRecipientByIdAsync(Guid id)
        {
            var recipient = await _recipientRepository.GetByIdAsync(id);
            return new RecipientDto
            {
                Id = recipient.Id,
                FirstName = recipient.FirstName,
                LastName = recipient.LastName,
                Email = recipient.Email,
                PhoneNumber = recipient.PhoneNumber,
                SenderId = recipient.SenderId
            };
        }

        public async Task UpdateRecipientContactInfoAsync(UpdateRecipientModel model)
        {
            var recipient = await _recipientRepository.GetByIdAsync(model.Id);
            recipient.FirstName = model.FirstName;
            recipient.LastName = model.LastName;
            recipient.Email = model.Email;
            recipient.PhoneNumber = model.PhoneNumber;
            recipient.SenderId = model.SenderId;
            await _recipientRepository.UpdateAsync(recipient);
        }
    }
}
