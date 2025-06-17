using System;

namespace DeliveryParcel.Application.Models.Recipients
{
    public class CreateRecipientModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public Guid SenderId { get; set; }
    }
}
