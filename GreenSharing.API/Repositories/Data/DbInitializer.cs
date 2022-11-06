using GreenSharing.API.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenSharing.API.Repositories.Data
{
    public static class DbInitializer
    {
        public static readonly Guid Farmer   = new Guid("35049D72-C586-4BED-92B0-918FD61CA92E");
        public static readonly Guid BankFood = new Guid("9EFCC1A2-DDF1-4AC4-B1D4-0E406A3BB6F3");
        public static readonly Guid Gleaner  = new Guid("E406461D-D732-4F4F-917F-A69128CB0599");

        public static readonly Guid Vegetable = new Guid("C5A7D3A5-365D-4CBA-A48E-1BBF6F39FDAD");
        public static readonly Guid Animal    = new Guid("B57F1520-9F64-4442-8414-A2B2DFDB8D13");
        public static readonly Guid Other     = new Guid("37183EBB-9C7F-41E8-8B55-3BF292A37C25");

        public static readonly Guid EventPriorityUrgent   = new Guid("2ED145EE-4231-4B52-A97A-2D89442A8742"); //"Urgent";   //ROUGE
        public static readonly Guid EventPriorityMedium   = new Guid("1DEDACAA-28F1-45FE-AD06-5E28A7A8E5D2"); //"Medium";   //ORANGE
        public static readonly Guid EventPriorityModerate = new Guid("77D86C1F-FFD7-49C4-AC5A-DF4F7F054517"); //"Moderate"; //JAUNE
        public static readonly Guid EventPriorityNormal   = new Guid("0F824A56-5507-4DD2-B694-879D2EDFE36C"); //Normal";    //VERT

        public static PasswordHasher<string> passwordHasser = new PasswordHasher<string>();

        public static void Initialize(GreenSharingContext context)
        {
            context.Database.EnsureCreated();

            var accountTypes = new AccountType[] {
                new AccountType {
                    Id = Farmer,
                    Name = "Farmer",
                    NameKey = "Farmer",
                    IsActive = true,
                    CreationDate = DateTime.UtcNow
                },
                new AccountType {
                    Id = BankFood,
                    Name = "BankFood",
                    NameKey = "BankFood",
                    IsActive = true,
                    CreationDate = DateTime.UtcNow
                },
                new AccountType {
                    Id = Gleaner,
                    Name = "Gleaner",
                    NameKey = "Gleaner",
                    IsActive = true,
                    CreationDate = DateTime.UtcNow
                }
            };
            // Look for any AccountType.
            if (context.AccountType.Any())
            {
                return;   // DB has been seeded
            }
            foreach (var accountType in accountTypes)
            {
                context.AccountType.Add(accountType);
            }
            context.SaveChanges();

            //ProductType
            var productTypes = new ProductType[] {
                new ProductType {
                    Id = Vegetable,
                    Name = "Vegetable",
                    Notes = "Vegetable"
                },
                new ProductType {
                    Id = Animal,
                    Name = "Animal",
                    Notes = "Animal"
                },
                new ProductType {
                    Id = Other,
                    Name = "Other",
                    Notes = "Other"
                }
            };
            // Look for any ProductType.
            if (context.ProductType.Any())
            {
                return;   // DB has been seeded
            }
            foreach (var productType in productTypes)
            {
                context.ProductType.Add(productType);
            }

            //EventPriority
            var eventPriorities = new EventPriority[] {
                new EventPriority {
                    Id = EventPriorityUrgent,
                    Code = "RED",
                    Notes = "Urgent",
                    IsActive = true,
                    IsDeleted = false
                },
                new EventPriority {
                    Id = EventPriorityMedium,
                    Code = "ORANGE",
                    Notes = "Urgent",
                    IsActive = true,
                    IsDeleted = false
                },
                new EventPriority {
                    Id = EventPriorityModerate,
                    Code = "YELLOW",
                    Notes = "Moderate",
                    IsActive = true,
                    IsDeleted = false 
                },
                new EventPriority {
                    Id = EventPriorityNormal,
                    Code = "VERT",
                    Notes = "Moderate",
                    IsActive = true,
                    IsDeleted = false
                }
            };
            // Look for any EventPriority.
            if (context.EventPriority.Any())
            {
                return;   // DB has been seeded
            }
            foreach (var eventPriority in eventPriorities)
            {
                context.EventPriority.Add(eventPriority);
            }

            //Account
            var acccounts = new Account[] {
                new Account { 
                    Id = new Guid("5985BA59-583B-49DC-9B44-FBB21382899F"),
                    AccountTypeId = Farmer,
                    Email = "farmer@yopmail.com",
                    Password = passwordHasser.HashPassword("5985BA59-583B-49DC-9B44-FBB21382899F", "MS@Farmer2022"),
                    IsActive = true,
                    IsConsentAccepted = true,
                    IsDeleted = false,
                    IsEnabled = true,
                    CreationDate = DateTime.UtcNow
                },
                new Account {
                    Id = new Guid("46FA891C-1AE4-4373-AAA8-1125432CE9BE"),
                    AccountTypeId = BankFood,
                    Email = "bankFood@yopmail.com",
                    Password = passwordHasser.HashPassword("5985BA59-583B-49DC-9B44-FBB21382899F", "MS@BankFood2022"),
                    IsActive = true,
                    IsConsentAccepted = true,
                    IsDeleted = false,
                    IsEnabled = true,
                    CreationDate = DateTime.UtcNow
                },
                new Account {
                    Id = new Guid("FDC6AA3D-7EEA-454C-A1AA-F76722087CD3"),
                    AccountTypeId = Gleaner,
                    Email = "gleaner@yopmail.com",
                    Password = passwordHasser.HashPassword("5985BA59-583B-49DC-9B44-FBB21382899F", "MS@Gleaner2022"),
                    IsActive = true,
                    IsConsentAccepted = true,
                    IsDeleted = false,
                    IsEnabled = true,
                    CreationDate = DateTime.UtcNow
                }
            };
            // Look for any Account.
            if (context.Account.Any())
            {
                return;   // DB has been seeded
            }
            foreach (var account in acccounts)
            {
                context.Account.Add(account);
            }
        }
    }
}
