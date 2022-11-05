using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenSharingAPI.Models
{
    public class Account
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SurName { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime? DisabledDate { get; set; }
        public DateTime? ConsentDate { get; set; }

        public Guid AccountTypeId { get; set; }
        public virtual AccountType AccountType { get; set; }


        public virtual IList<AccountLocation> AccountLocations { get; set; } = new List<AccountLocation>();
    }
}