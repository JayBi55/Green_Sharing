using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenSharing.API.Repositories.DataAccessLayer.Models
{
    [Table("AccountLocation", Schema = "location")]
    public class AccountLocation
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public string Title { get; set; }  //Mr, Sir, Miss ...
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Door { get; set; }
        public string ZipCode { get; set; }

        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longtitude { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Account Account { get; set; }
    }
}

