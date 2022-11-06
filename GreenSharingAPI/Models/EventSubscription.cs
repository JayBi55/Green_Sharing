using System;
using Microsoft.Extensions.Logging;

namespace GreenSharingAPI.Models
{
    public class EventSubscription
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public int Carpooling { get; set; }

        public Guid EventId { get; set; }
        public virtual Event Event { get; set; }

        public Guid GleanerId { get; set; }
        public virtual Gleaner Gleaner { get; set; }
    }
}

