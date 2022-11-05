using System;
namespace GreenSharingAPI.Models
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public float Duration { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public float Capacity { get; set; }
        public string Status { get; set; }

        public Guid FarmerProductId { get; set; }
        public virtual FarmerProduct FarmerProduct { get; set; }

        public Guid PriorityId { get; set; }
        public virtual EventPriority EventPriority { get; set; }

        public Guid ProductTypeId { get; set; }
        public virtual ProductType ProductType { get; set; }


    }
}

