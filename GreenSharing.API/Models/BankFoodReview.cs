using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenSharing.API.Models
{
    public class BankFoodReview
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }

        /// <summary>
        /// Score que la persone donne au BankFood
        /// </summary>
        public long Score { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        //FK
        public Guid BankFoodId { get; set; }
        public Guid AccountId { get; set; }
        public virtual Account Account { get; set; }
        public virtual BankFood BankFood { get; set; }
    }
}
