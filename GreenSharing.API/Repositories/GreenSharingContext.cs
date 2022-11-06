using GreenSharing.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace GreenSharing.API.Repositories
{
    public class GreenSharingContext : DbContext
    {
        public static readonly Guid FarmerId  = new Guid("35049D72-C586-4BED-92B0-918FD61CA92E");
        public static readonly Guid BankFoodId= new Guid("9EFCC1A2-DDF1-4AC4-B1D4-0E406A3BB6F3");
        public static readonly Guid GleanerId = new Guid("E406461D-D732-4F4F-917F-A69128CB0599");

        public static readonly Guid Vegetable = new Guid("C5A7D3A5-365D-4CBA-A48E-1BBF6F39FDAD");
        public static readonly Guid Animal    = new Guid("B57F1520-9F64-4442-8414-A2B2DFDB8D13");
        public static readonly Guid Other     = new Guid("37183EBB-9C7F-41E8-8B55-3BF292A37C25");

        public static readonly Guid UrgentId  = new Guid("2ED145EE-4231-4B52-A97A-2D89442A8742");//"Urgent";   //ROUGE
        public static readonly Guid MediumId  = new Guid("1DEDACAA-28F1-45FE-AD06-5E28A7A8E5D2");//"Medium";   //ORANGE
        public static readonly Guid ModerateId= new Guid("77D86C1F-FFD7-49C4-AC5A-DF4F7F054517");//"Moderate"; //JAUNE
        public static readonly Guid NormalId  = new Guid("0F824A56-5507-4DD2-B694-879D2EDFE36C");//"Normal";   //VERT

        public static PasswordHasher<string> passwordHasser = new PasswordHasher<string>();

        public GreenSharingContext(DbContextOptions<GreenSharingContext> options): base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Logger.InfoFormat("Configuring DbContext");
            //optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["GreenSharingContext"].ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //TODO: Find how to avoid this ...or automate this !!!
            //TODO: See: https://github.com/aspnet/EntityFrameworkCore/issues/3815
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().Where(e => !e.IsOwned()).SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            //Seed Data
            //AccountType
            modelBuilder.Entity<AccountType>().HasData(
                new AccountType
                { Id = FarmerId, Name = "Farmer",NameKey = "Farmer",  IsActive = true, IsDeleted= false, CreationDate = DateTime.UtcNow },
                new AccountType
                {
                    Id = BankFoodId,
                    Name = "BankFood",
                    NameKey = "BankFood",
                    IsActive = true,
                    IsDeleted = false,
                    CreationDate = DateTime.UtcNow
                },
                new AccountType
                {
                    Id = GleanerId,
                    Name = "Gleaner",
                    NameKey = "Gleaner",
                    IsActive = true,
                    IsDeleted = false,
                    CreationDate = DateTime.UtcNow
                });

            //ProductType
            modelBuilder.Entity<ProductType>().HasData(
                new ProductType
                {
                    Id = Vegetable,
                    Name = "Vegetable",
                    Notes = "Vegetable",
                    IsActive = true,
                    IsDeleted = false
                },
                new ProductType
                {
                    Id = Animal,
                    Name = "Animal",
                    Notes = "Animal",
                    IsActive = true,
                    IsDeleted = false
                },
                new ProductType
                {
                    Id = Other,
                    Name = "Other",
                    Notes = "Other",
                    IsActive = true,
                    IsDeleted = false
                });

            //EventPriority
            modelBuilder.Entity<EventPriority>().HasData(
                new EventPriority
                {
                    Id = UrgentId,
                    Code = "RED",
                    Notes = "Urgent",
                    IsActive = true,
                    IsDeleted = false
                },
                new EventPriority
                {
                    Id = MediumId,
                    Code = "ORANGE",
                    Notes = "Medium",
                    IsActive = true,
                    IsDeleted = false
                },
                new EventPriority
                {
                    Id = ModerateId,
                    Code = "YELLOW",
                    Notes = "Moderate",
                    IsActive = true,
                    IsDeleted = false
                },
                new EventPriority
                {
                    Id = NormalId,
                    Code = "VERT",
                    Notes = "Normal",
                    IsActive = true,
                    IsDeleted = false
                });

            //Account
            modelBuilder.Entity<Account>().HasData(
                new Account
                {
                    Id = new Guid("5985BA59-583B-49DC-9B44-FBB21382899F"),
                    AccountTypeId = FarmerId,
                    Email = "farmer@yopmail.com",
                    FirstName = "Farmer",
                    LastName = "John Doe",
                    SurName = "Big J.",
                    Password = passwordHasser.HashPassword("5985BA59-583B-49DC-9B44-FBB21382899F", "MS@Farmer2022"),
                    IsActive = true,
                    IsConsentAccepted = true,
                    IsDeleted = false,
                    IsEnabled = true,
                    CreationDate = DateTime.UtcNow
                },
                new Account
                {
                    Id = new Guid("46FA891C-1AE4-4373-AAA8-1125432CE9BE"),
                    AccountTypeId = BankFoodId,
                    Email = "bankFood@yopmail.com",
                    FirstName = "Moisson Montreal",
                    LastName = "Moisson Montreal",
                    SurName = "Give Back to Community",
                    Password = passwordHasser.HashPassword("5985BA59-583B-49DC-9B44-FBB21382899F", "MS@BankFood2022"),
                    IsActive = true,
                    IsConsentAccepted = true,
                    IsDeleted = false,
                    IsEnabled = true,
                    CreationDate = DateTime.UtcNow
                },
                new Account
                {
                    Id = new Guid("FDC6AA3D-7EEA-454C-A1AA-F76722087CD3"),
                    AccountTypeId = GleanerId,
                    Email = "gleaner@yopmail.com",
                    FirstName = "Gleaner",
                    LastName = "Jeanette Odu",
                    SurName = "Jeane",
                    Password = passwordHasser.HashPassword("5985BA59-583B-49DC-9B44-FBB21382899F", "MS@Gleaner2022"),
                    IsActive = true,
                    IsConsentAccepted = true,
                    IsDeleted = false,
                    IsEnabled = true,
                    CreationDate = DateTime.UtcNow
                });
        }

        public DbSet<AccountType> AccountType { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<Farmer> Farmer { get; set; }
        public DbSet<BankFood> BankFood { get; set; }
        public DbSet<Gleaner> Gleaner { get; set; }
        public DbSet<GleanerReview> GleanerReview { get; set; }

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
    }
}
