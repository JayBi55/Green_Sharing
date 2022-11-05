using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GreenSharing.API.Models
{
    public class BankFood
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Availability { get; set; }
        public long DistanceMax { get; set; }


        [NotMapped]
        public string Address { get { return Account.AccountLocations.FirstOrDefault( x => x.AccountId == Id )?.Address; } }

        //FK
        public Guid AccountId { get; set; }
        public virtual Account Account { get; set; }
    }
}
