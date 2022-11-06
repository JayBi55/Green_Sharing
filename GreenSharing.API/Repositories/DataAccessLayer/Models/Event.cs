using System;
namespace GreenSharing.API.Repositories.DataAccessLayer.Models
{
    public class Event
    {
        public static readonly long DeafultCapacityMinimum = 5;

        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public long Duration { get; set; }
        public long GleanedQuantity { get; set; }
        public long MinimumCapacity { get; set; }
        public long CarpoolingPlaces { get; set; } //number of Places available for common transportation
        public bool IsCarpoolingEnabled { get; set; }

        public string Description { get; set; }
        public string Contact { get; set; }
        public string Status { get; set; }

        //
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Door { get; set; }
        public string ZipCode { get; set; }
        public string Address { get; set; }

        //
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public Guid FarmerProductId { get; set; }
        public virtual FarmerProduct FarmerProduct { get; set; }

        public Guid EventPriorityId { get; set; }
        public virtual EventPriority EventPriority { get; set; }
    }
}

