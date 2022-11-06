using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GreenSharing.API.Repositories.DataAccessLayer.Models
{
    [Table("AccountSession", Schema = "identity")]
    public class AccountSession
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }

        public Guid DeviceInfoId { get; set; }

        public string Token { get; set; }
        public string TokenFcm { get; set; }
        public DateTime LastLoginTime { get; set; }
        public DateTime ActualLoginTime { get; set; }
        public DateTime Expiration { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime? ClosingDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Account Account { get; set; }
        public virtual DeviceInfo DeviceInfo { get; set; }
    }
}
