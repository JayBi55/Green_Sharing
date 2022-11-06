using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenSharing.API.Repositories.DataAccessLayer.Models
{
    [Table("AccountType", Schema = "identity")]
    public class AccountType
    {
        public static readonly Guid Farmer   = new Guid("35049D72-C586-4BED-92B0-918FD61CA92E");
        public static readonly Guid BankFood = new Guid("9EFCC1A2-DDF1-4AC4-B1D4-0E406A3BB6F3");
        public static readonly Guid Gleaner  = new Guid("E406461D-D732-4F4F-917F-A69128CB0599");

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string NameKey { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime? ClosingDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public virtual IList<Account> Account { get; set; } = new List<Account>();
    }

    public static class AccountTypes
    {
        public const string Farmer = "Farmer";
        public const string BankFood = "BankFood";
        public const string Gleaner = "Gleaner";
    }

    public enum AccountTypeEnum
    {
        Farmer = 1,
        BankFood = 2,
        Gleaner = 3
    }
}
