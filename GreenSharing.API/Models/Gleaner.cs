using System;
namespace GreenSharing.API.Models
{
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

