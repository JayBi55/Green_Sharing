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
        public Guid FarmerID { get; set; }
        public virtual Farmer Farmer { get; set; }

        public Guid AccountID { get; set; }
        public virtual Account Account { get; set; }
        
    }
}

