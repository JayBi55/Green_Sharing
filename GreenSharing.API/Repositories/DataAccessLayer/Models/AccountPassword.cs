using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GreenSharing.API.Repositories.DataAccessLayer.Models
{
    [Table("AccountPassword", Schema = "identity")]
    public class AccountPassword
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public Guid AuthorId { get; set; }
        [Required]
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? ClosingDate { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual Account Account { get; set; }
        public virtual Account Author { get; set; }
    }
}
