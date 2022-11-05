using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenSharingAPI.Models
{
    public class BankFoodProductConsumable
    {
        public Guid Id { get; set; }
        public string Notes { get; set; }
        public string Quantity { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        //FK
        public Guid BankFoodID { get; set; }
        public Guid ProductID { get; set; }

        public virtual Product Produit{ get; set; }
        public virtual BankFood BankFood { get; set; }
    }
}
