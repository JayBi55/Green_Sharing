using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenSharingAPI.Models
{
    public class GreenSharingContext : DbContext
    {
        public GreenSharingContext(DbContextOptions<GreenSharingContext> options): base(options)
        {
        }

        public DbSet<AccountType> AccountType { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<Farmer> Farmer { get; set; }
        public DbSet<BankFood> BankFood { get; set; }
        public DbSet<Gleaner> Gleaner { get; set; }

        public DbSet<AccountLocation> AccountLocation { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<FarmerProduct> FarmerProduct { get; set; }

        public DbSet<FarmerReview> FarmerReview { get; set; }
        public DbSet<BankFoodReview> BankFoodReview { get; set; }
        public DbSet<BankFoodProductConsumable> BankFoodProductConsumable { get; set; }

        public DbSet<Event> Event { get; set; }
        public DbSet<EventPriority> EventPriority { get; set; }
        public DbSet<EventReview> EventReview { get; set; }
        public DbSet<EventSubscription> EventSubscription { get; set; }
        public DbSet<GleanerReview> GleanerReview { get; set; }
    }
}
