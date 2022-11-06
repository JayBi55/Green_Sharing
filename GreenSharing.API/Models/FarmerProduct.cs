using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenSharing.API.Models
{
    /// <summary>
    /// Produits offerts par le Fermier
    /// </summary>
    public class FarmerProduct
    {
        public Guid Id { get; set; }
        public string   Notes { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        //FK
        public Guid FarmerId { get; set; }
        public Guid ProductId { get; set; }

        public virtual Farmer Farmer { get; set; }
        public virtual Product Product { get; set; }
    }
}
