using System;
namespace GreenSharingAPI.Models
{
    public class Gleaner
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string contact { get; set; }
        public float dist_max { get; set; }
        public float score{ get; set; }

        public Guid AccountId { get; set; }

        public virtual Account Account { get; set; }

    }
}

