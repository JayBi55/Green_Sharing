using System;
namespace GreenSharing.API.Repositories.DataAccessLayer.Models
{
    public class EventPriority
    {
        public static readonly Guid EventPriorityUrgent = new Guid("2ED145EE-4231-4B52-A97A-2D89442A8742"); //"Urgent";   //ROUGE
        public static readonly Guid EventPriorityMedium = new Guid("1DEDACAA-28F1-45FE-AD06-5E28A7A8E5D2"); //"Medium";   //ORANGE
        public static readonly Guid EventPriorityModerate = new Guid("77D86C1F-FFD7-49C4-AC5A-DF4F7F054517"); //"Moderate"; //JAUNE
        public static readonly Guid EventPriorityNormal = new Guid("0F824A56-5507-4DD2-B694-879D2EDFE36C"); //Normal";    //VERT

        public Guid Id { get; set; }
        public string Code { get; set; }  
        public string Notes { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}

