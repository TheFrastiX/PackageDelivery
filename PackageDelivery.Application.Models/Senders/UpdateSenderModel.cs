using System;

namespace DeliveryParcel.Application.Models.Senders
{
    public class UpdateSenderModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
    }
}
