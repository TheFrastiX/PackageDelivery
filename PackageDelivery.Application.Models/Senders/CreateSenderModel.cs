using System;

namespace DeliveryParcel.Application.Models.Senders
{
    public class CreateSenderModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
    }
}
