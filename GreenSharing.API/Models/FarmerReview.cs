using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenSharing.API.Models
{
    public class FarmerReview
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }

        /// <summary>
        /// Score que la persone donne au Farmer
        /// </summary>
        public long Score { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        //FK
        public Guid FarmerId { get; set; }
        public Guid AccountId { get; set; }
        public virtual Account Account { get; set; }
        public virtual Farmer Farmer{ get; set; }
    }
}
