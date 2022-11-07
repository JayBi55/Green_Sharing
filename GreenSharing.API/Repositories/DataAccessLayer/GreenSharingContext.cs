using GreenSharing.API.Repositories.DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace GreenSharing.API.Repositories.DataAccessLayer
{
    public class GreenSharingContext : DbContext
    {
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
            modelBuilder.Entity<AccountType>(entity =>
            {
                entity.HasIndex(e => e.Name).IsUnique();
                entity.HasIndex(e => e.NameKey).IsUnique();
                entity.HasData(
                new AccountType
                {
                    Id = GreenSharing.API.Repositories.DataAccessLayer.Models.AccountType.FarmerId,
                    Name = "Farmer",
                    NameKey = "Farmer",
                    IsActive = true,
                    IsDeleted = false,
                    CreationDate = DateTime.UtcNow
                },
                new AccountType
                {
                    Id = GreenSharing.API.Repositories.DataAccessLayer.Models.AccountType.BankFoodId,
                    Name = "BankFood",
                    NameKey = "BankFood",
                    IsActive = true,
                    IsDeleted = false,
                    CreationDate = DateTime.UtcNow
                },
                new AccountType
                {
                    Id = GreenSharing.API.Repositories.DataAccessLayer.Models.AccountType.GleanerId,
                    Name = "Gleaner",
                    NameKey = "Gleaner",
                    IsActive = true,
                    IsDeleted = false,
                    CreationDate = DateTime.UtcNow
                });
            });

            //ProductType
            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.HasIndex(e => e.Name).IsUnique();
                entity.HasData(
                new ProductType
                {
                    Id = GreenSharing.API.Repositories.DataAccessLayer.Models.ProductType.Vegetable,
                    Name = "Vegetable",
                    Notes = "Vegetable",
                    IsActive = true,
                    IsDeleted = false
                },
                new ProductType
                {
                    Id = GreenSharing.API.Repositories.DataAccessLayer.Models.ProductType.Animal,
                    Name = "Animal",
                    Notes = "Animal",
                    IsActive = true,
                    IsDeleted = false
                },
                new ProductType
                {
                    Id = GreenSharing.API.Repositories.DataAccessLayer.Models.ProductType.Other,
                    Name = "Other",
                    Notes = "Other",
                    IsActive = true,
                    IsDeleted = false
                });
            });

            //EventPriority
            modelBuilder.Entity<EventPriority>(entity =>
            {
                entity.HasIndex(e => e.Code).IsUnique();
                entity.HasData(
                new EventPriority
                {
                    Id = GreenSharing.API.Repositories.DataAccessLayer.Models.EventPriority.UrgentId,
                    Code = "RED",
                    Notes = "Urgent",
                    IsActive = true,
                    IsDeleted = false
                },
                new EventPriority
                {
                    Id = GreenSharing.API.Repositories.DataAccessLayer.Models.EventPriority.MediumId,
                    Code = "ORANGE",
                    Notes = "Medium",
                    IsActive = true,
                    IsDeleted = false
                },
                new EventPriority
                {
                    Id = GreenSharing.API.Repositories.DataAccessLayer.Models.EventPriority.ModerateId,
                    Code = "YELLOW",
                    Notes = "Moderate",
                    IsActive = true,
                    IsDeleted = false
                },
                new EventPriority
                {
                    Id = GreenSharing.API.Repositories.DataAccessLayer.Models.EventPriority.NormalId,
                    Code = "VERT",
                    Notes = "Normal",
                    IsActive = true,
                    IsDeleted = false
                });
            });

            //Account
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasIndex(e => e.UserName).IsUnique();
                entity.HasIndex(e => e.Email).IsUnique();
                entity.HasData(
                new Account
                {
                    Id = new Guid("5985BA59-583B-49DC-9B44-FBB21382899F"),
                    AccountTypeId = GreenSharing.API.Repositories.DataAccessLayer.Models.AccountType.FarmerId,
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
                    AccountTypeId = GreenSharing.API.Repositories.DataAccessLayer.Models.AccountType.BankFoodId,
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
                    AccountTypeId = GreenSharing.API.Repositories.DataAccessLayer.Models.AccountType.GleanerId,
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
            });

            //OAuthProvider
            modelBuilder.Entity<OAuthProvider>(entity =>
            {
                entity.HasIndex(e => e.Name).IsUnique();
                entity.HasData(
                new OAuthProvider
                {
                    Id = GreenSharing.API.Repositories.DataAccessLayer.Models.OAuthProvider.GoogleId,
                    Name = "Google",
                    IsActive = true,
                    IsDeleted = false
                },
                new OAuthProvider
                {
                    Id = GreenSharing.API.Repositories.DataAccessLayer.Models.OAuthProvider.AppleId,
                    Name = "Apple",
                    IsActive = true,
                    IsDeleted = false
                },
                new OAuthProvider
                {
                    Id = GreenSharing.API.Repositories.DataAccessLayer.Models.OAuthProvider.FacebookId,
                    Name = "Facebook",
                    IsActive = true,
                    IsDeleted = false
                }
                );
            });

            //AddressType
            modelBuilder.Entity<AddressType>(entity =>
            {
                entity.HasIndex(e => e.Name).IsUnique();
                entity.HasIndex(e => e.NameKey).IsUnique();
                entity.HasData(
                new AddressType
                {
                    Id = GreenSharing.API.Repositories.DataAccessLayer.Models.AddressType.PrimaryId,
                    Name = "Primary",
                    NameKey = "Primary",
                    IsActive = true,
                    IsDeleted = false,
                    CreationDate = DateTime.UtcNow
                },
                new AddressType
                {
                    Id = GreenSharing.API.Repositories.DataAccessLayer.Models.AddressType.SecondaryId,
                    Name = "Secondary",
                    NameKey = "Secondary",
                    IsActive = true,
                    IsDeleted = false,
                    CreationDate = DateTime.UtcNow
                },
                new AddressType
                {
                    Id = GreenSharing.API.Repositories.DataAccessLayer.Models.AddressType.OtherId,
                    Name = "Other",
                    NameKey = "Other",
                    IsActive = true,
                    IsDeleted = false,
                    CreationDate = DateTime.UtcNow
                }
                );
            });

            //AccountLocation
            modelBuilder.Entity<AccountLocation>(entity =>
            {
                entity.Property( x=> x.AddressTypeId).HasDefaultValue(GreenSharing.API.Repositories.DataAccessLayer.Models.AddressType.PrimaryId);
            });

            //Event
            modelBuilder.Entity<Event>(entity =>
            {
                entity.Property(x => x.MinimumCapacity).HasDefaultValue(GreenSharing.API.Repositories.DataAccessLayer.Models.Event.DeafultCapacityMinimum);
            });
        }

        public DbSet<Account> Account { get; set; }
        public DbSet<Farmer> Farmer { get; set; }
        public DbSet<BankFood> BankFood { get; set; }
        public DbSet<Gleaner> Gleaner { get; set; }
        public DbSet<GleanerReview> GleanerReview { get; set; }

        public DbSet<DeviceInfo> DeviceInfo { get; set; }
        public DbSet<OAuthProvider> OAuthProvider { get; set; }
        public DbSet<AccountLocation> AccountLocation { get; set; }
        public DbSet<AccountOAuth> AccountOAuth { get; set; }
        public DbSet<AccountPassword> AccountPassword { get; set; }
        public DbSet<AccountSession> AccountSession { get; set; }
        public DbSet<AccountType> AccountType { get; set; }
        public DbSet<AddressType> AddressType { get; set; }
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
