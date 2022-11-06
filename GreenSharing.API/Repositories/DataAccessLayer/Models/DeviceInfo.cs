using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GreenSharing.API.Repositories.DataAccessLayer.Models
{
    [Table("DeviceInfo", Schema = "identity")]
    public class DeviceInfo
    {
        public Guid Id { get; set; }
        public string DeviceId { get; set; }
        public string DeviceType { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string VersionString { get; set; }
        public string Name { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime? ClosingDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
