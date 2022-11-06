using GreenSharing.API.Dtos;
using GreenSharing.API.Repositories.DataAccessLayer;
using GreenSharing.API.Repositories.DataAccessLayer.Models;
using GreenSharing.API.Repositories.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GreenSharing.API.Repositories
{
    public  class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public PasswordHasher<string> passwordHasser = new PasswordHasher<string>();

        public AccountRepository(GreenSharingContext context) : base(context)
        {

        }

        /// <summary>
        /// CreateAsync
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        new public Task<int> CreateAsync(Account account)
        {
            try
            {
                account.Password = passwordHasser.HashPassword(account.Id.ToString(), account.Password);
                account.CreationDate = DateTime.UtcNow;
                account.IsActive = true;
                account.IsEnabled = false;
                account.IsConsentAccepted = true;

                return base.CreateAsync(account);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        new public async Task<int> DeleteAsync(Guid accountId)
        {
            int result = 0;
            try
            {
                var account = await FindAsync(accountId);

                account.DisabledDate = DateTime.UtcNow;
                account.IsDeleted = true;
                account.IsActive = false;
                account.IsEnabled = false;

                await UpdateAsync(account);
                result = await base.DeleteAsync(accountId);
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }

        public async Task<Account> LoginAsync(LoginDTO loginDto)
        {
            Account account = null;

            try
            {
                account = await FindAsync(c => c.Email == loginDto.Email && c.IsActive && !c.IsDeleted /*&& c.IsEnabled & c.IsConsentAccepted*/);
                bool passwordValidation = false;
                if (account != null)
                {
                    passwordValidation = VerifiedHashedPassword(account, loginDto.Password);
                }
                //If account is Found 
                if (account != null && passwordValidation)
                {
                    //An account will now be associated with the event.
                    //TODO:
                }
                else 
                {
                    //Manage 
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return account;
        }

        public new async Task<IEnumerable<Account>> FindAllAsync(Expression<Func<Account, bool>> whereExpression)
        {
            var entities = new List<Account>();

            try
            {
                entities = await DbSet
                    .Include(x => x.AccountType)
                    .Include(x => x.AccountLocations)
                    .Where(whereExpression).ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }

            return entities;
        }
        public bool VerifiedHashedPassword(Account account, string password)
        {
            PasswordVerificationResult verification = passwordHasser.VerifyHashedPassword(account.Id.ToString(), account.Password, password);
            bool result = true;


            if (verification.Equals(PasswordVerificationResult.Failed))
            {
                result = false;
            }

            return result;
        }
    }
}
