using System;
namespace GreenSharing.API.Models
{
    public class EventPriority
    {
        public const string Urgent   = "Urgent";          //ROUGE
        public const string Medium   = "Medium";          //ORANGE
        public const string Moderate = "Moderate";        //JAUNE
        public const string Normal   = "Normal";          //VERT

        public Guid Id { get; set; }
        public string Code { get; set; }  
        public string Notes { get; set; }
    }
}

