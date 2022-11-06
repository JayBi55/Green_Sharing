using System;
using YamlDotNet.Core;

namespace GreenSharing.API.Models
{
    public class GleanerReview
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }

        /// <summary>
        /// Score que la persone donne au Gleener
        /// </summary>
        public long Score { get; set; }

        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }


        //FK
        public Guid GleanerId { get; set; }
        public virtual Gleaner Gleaner { get; set; }

        public Guid AccountId { get; set; }
        public virtual Account Account { get; set; }        
    }
}

