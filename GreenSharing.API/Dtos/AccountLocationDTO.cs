using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenSharing.API.Dtos
{
    public class AccountLocationDTO
    {
        public static readonly string Primary = "Primary";
        public static readonly string Secondary = "Secondary";
        public static readonly string Other = "Other";

        public string Title { get; set; }  //Mr, Sir, Miss ...
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Door { get; set; }
        public string ZipCode { get; set; }

        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longtitude { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
