using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenSharing.API.Repositories.DataAccessLayer.Models
{
    [Table("OAuthProvider", Schema = "identity")]
    public class OAuthProvider
    {
        public static Guid AppleId    = new Guid("7756997b-5808-434d-ad43-7e2d28b06a84");
        public static Guid GoogleId   = new Guid("ede4680a-eb19-43db-82c9-2bdfe61c0e2c");
        public static Guid FacebookId = new Guid("f35e5759-a9a5-4ea9-8c96-3c900fedde91");
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
