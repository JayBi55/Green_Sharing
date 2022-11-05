using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenSharingAPI.Models
{
    public class Farmer
    {
        public Guid Id { get; set; }
        public string FarmName { get; set; }
        public DateTime Availability { get; set; }

        //FK
        public Guid AccountId { get; set; }
        public virtual Account Account { get; set; }
    }
}
