using System;
using Microsoft.Extensions.Logging;

namespace GreenSharing.API.Models
{
    public class EventReview
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }

        public Guid EventId { get; set; }
        public virtual Event Event { get; set; }

        public Guid AccountId { get; set; }
        public virtual Account Account { get; set; }
    }
}

