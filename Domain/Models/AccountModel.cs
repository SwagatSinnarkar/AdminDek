using System;
using System.Web;

namespace Domain.Models
{
    public class AccountModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }
        public string Mobile { get; set; }

        //Location
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public int AccountId { get; set; }

        //Image
        public HttpPostedFileWrapper ImageFile { get; set; }
        public byte[] ImageByte { get; set; }
        public string ImagePath { get; set; }
        public string ImageName { get; set; }
    }
}