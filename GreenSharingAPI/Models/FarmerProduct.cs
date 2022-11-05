using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenSharingAPI.Models
{
    public class FarmerProduct
    {
        public Guid Id { get; set; }
        public string   Notes { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        //FK
        public Guid FarmerID { get; set; }
        public Guid ProductID { get; set; }

        public virtual Farmer Farmer { get; set; }
        public virtual Produit product{ get; set; }
    }
}
