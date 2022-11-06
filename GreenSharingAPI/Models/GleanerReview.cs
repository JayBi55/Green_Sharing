using System;
using YamlDotNet.Core;

namespace GreenSharingAPI.Models
{
    public class GleanerReview
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }

        //FK
        public Guid GleanerId { get; set; }
        public virtual Gleaner Gleaner { get; set; }

        public Guid AccountId { get; set; }
        public virtual Account Account { get; set; }        
    }
}

