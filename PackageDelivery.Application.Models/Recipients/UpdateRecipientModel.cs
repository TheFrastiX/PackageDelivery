using System;

namespace DeliveryParcel.Application.Models.Recipients
{
    public class UpdateRecipientModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public Guid SenderId { get; set; }
    }
}
