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

        //FK
        public Guid AccountId { get; set; }
        public virtual Account Account { get; set; }
    }
}
