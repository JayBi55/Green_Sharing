using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GreenSharing.API.Repositories.DataAccessLayer.Models
{
    [Table("AccountOAuth", Schema = "identity")]
    public class AccountOAuth
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public Guid OAuthProviderId { get; set; }
        public string UserProviderId { get; set; }
        public string Email { get; set; }
        public bool IsEmailVerified { get; set; }
        public string Token { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        [NotMapped]
        public Guid AccountTypeId { get { return Account.AccountTypeId; } }

        public virtual Account Account { get; set; }
        public virtual OAuthProvider OAuthProvider { get; set; }
    }
}
