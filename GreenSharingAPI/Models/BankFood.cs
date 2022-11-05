using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenSharingAPI.Models
{
    public class BankFood
    {
        public Guid Id { get; set; }
        public string nom_banque { get; set; }
        public string dresse { get; set; }
        public string province { get; set; }
        public int contact { get; set; }
        public string disponibilité_bankFood { get; set; }
        public int distance_max { get; set; }
        //FK
        public Guid accountID { get; set; }
        public virtual Account Account { get; set; }
    }
}
}
