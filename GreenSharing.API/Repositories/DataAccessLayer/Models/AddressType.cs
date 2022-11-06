using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenSharing.API.Repositories.DataAccessLayer.Models
{
    [Table("AddressType", Schema = "location")]
    public class AddressType
    {
        public static readonly Guid PrimaryId   = new Guid("7B22DDB4-48B0-456D-8ADA-EC438B8DF9B1");
        public static readonly Guid SecondaryId = new Guid("AE7D9680-3151-4B7D-B11D-401B41ECAA16");
        public static readonly Guid OtherId     = new Guid("25763A24-5F9D-4704-9B86-7313391AF7D2");

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string NameKey { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime? DisabledDate { get; set; }
    }
}
