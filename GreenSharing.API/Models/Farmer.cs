using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GreenSharing.API.Models
{
    [Table("Farmer", Schema = "identity")]
    public class Farmer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public DateTime Availability { get; set; }

        [NotMapped]
        public long Score
        {
            get
            {
                return 5; //TODO: Doit etre une compilation de ses FamerReview.Score
            }
        }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        //FK
        public Guid AccountId { get; set; }
        public virtual Account Account { get; set; }
    }
}
