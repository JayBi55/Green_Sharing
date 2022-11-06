using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenSharing.API.Repositories.DataAccessLayer.Models
{
    [Table("Gleaner", Schema = "identity")]
    public class Gleaner
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public long DistanceMax { get; set; }

        [NotMapped]
        public long Score {
            get { 
                return 5; //TODO: Doit etre une compilation de ses GleanerReview.Score
            } 
        }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public Guid AccountId { get; set; }
        public virtual Account Account { get; set; }
    }
}

