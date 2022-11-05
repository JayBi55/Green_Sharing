using System;
namespace GreenSharingAPI.Models
{
    public class AccountLocation
    {
        public Guid Id { get; set; }
        public double latitude { get; set; }
        public double longtitude { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }

        public Guid AccountId { get; set; }
        public virtual Account Account { get; set; }

    }
}

