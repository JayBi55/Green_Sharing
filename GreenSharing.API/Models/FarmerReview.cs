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
        //FK
        public Guid FarmerID { get; set; }
        public Guid AccountID { get; set; }
        public virtual Account Account { get; set; }
        public virtual Farmer Farmer{ get; set; }
    }
}
