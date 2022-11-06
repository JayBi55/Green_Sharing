using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenSharing.API.Models
{
    [Table("Gleaner", Schema = "identity")]
    public class Gleaner
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public long DistanceMax { get; set; }
        public long Score{ get; set; }

        public Guid AccountId { get; set; }
        public virtual Account Account { get; set; }
    }
}

