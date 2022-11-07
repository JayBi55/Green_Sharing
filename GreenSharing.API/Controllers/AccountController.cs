using GreenSharing.API.Dtos;
using GreenSharing.API.Extensions;
using GreenSharing.API.Repositories.DataAccessLayer.Models;
using GreenSharing.API.Repositories.Interface;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GreenSharing.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(AccountController));

        //Repositories For Tables/Models where we have Custom Methods others than CRUD (CreateAsync ReadAsync UpdateAsync DeleteAsync GetAllAsync)
        private readonly IAccountRepository _accountRepository;

        //Generic Repositories For Tables/Models where we do only CreateAsync ReadAsync UpdateAsync DeleteAsync GetAllAsync 
        private readonly IGenericRepository<AccountType> _accountTypeRepository;
        private readonly IGenericRepository<AccountLocation> _accountLocationRepository;
        private readonly IGenericRepository<AddressType> _addresTypeRepository;

        //MANDTORY
        public AccountController(IAccountRepository accountRepository,
            IGenericRepository<AccountType> accountTypeRepository, 
            IGenericRepository<AccountLocation> accountLocationRepository,
            IGenericRepository<AddressType> addresTypeRepository)
        {
            _accountRepository = accountRepository;
            _accountTypeRepository = accountTypeRepository;
            _accountLocationRepository = accountLocationRepository;
            _addresTypeRepository = addresTypeRepository;
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(LoginDTO), 200)]
        [ProducesResponseType(typeof(void), 400)]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
        {
            Account account;
            try
            {
                account = await _accountRepository.LoginAsync(loginDto);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            return Ok(account);
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(Account), 200)]
        [ProducesResponseType(typeof(void), 400)]
        public async Task<IActionResult> Create([FromBody] AccountDTO accountDto)
        {
            Account accountCreated = null;
            try
            {
                //1. Find the AccounType related
                //Farmer, Gleaner, BankFood
                AccountType accountType = await _accountTypeRepository.FindAsync(x => (/*x.Id == accountDto.AccountTypeId ||*/ x.Name.ToLower() == accountDto.AccountTypeName.ToLower()));
                if (accountType == null)
                {
                    //TODO: Throw ...l'accountType n'existe pas !                
                }
                else
                {
                    var account = accountDto.ToEntity<AccountDTO, Account>();
                    //2. Create the Account attaching its AccounType
                    account.AccountType = accountType;
                    account.AccountTypeId = accountType.Id;
                    account.IsActive = true;
                    account.IsDeleted = false;
                    account.IsConsentAccepted = true;
                    if (accountDto.AccountLocationDtos.Any())
                    {
                        account.AccountLocations = new List<AccountLocation>();
                        foreach(var location in accountDto.AccountLocationDtos)
                        {
                            var accountLocation = location.ToEntity<AccountLocationDTO, AccountLocation>();
                            accountLocation.IsActive = true;
                            accountLocation.IsDeleted = false;

                            var addresType = await _addresTypeRepository.FindAsync(x => x.Name.ToLower() == location.AddressTypeName.ToLower());

                            if (addresType == null) {
                                accountLocation.AddressTypeId = AddressType.PrimaryId;
                            }
                            else
                            {
                                accountLocation.AddressType = addresType;
                                accountLocation.AddressTypeId = addresType.Id;
                            }

                            account.AccountLocations.Add(accountLocation);
                        }
                    }
                    var result = await _accountRepository.CreateAsync(account);

                    //3. If there is Any AccountLocation Specified and createe it
                    //Creates Location if provided !
                    if (account.AccountLocations.Any()) {
                        foreach (var location in account.AccountLocations) {
                            await _accountLocationRepository.CreateOrUpdateAsync(location);
                        }
                    }
                }
            }
            catch (Exception e)

            {
                return BadRequest(e);
            }

            return Ok(accountCreated);
        }

        // GET api/<AccountController>/5
        [HttpGet("{accountId}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(Account), 200)]
        [ProducesResponseType(typeof(void), 400)]
        public async Task<IActionResult> Get(Guid accountId)
        {
            Account account ;
            try
            {
                account = await _accountRepository.FindAsync(x => x.Id == accountId);
            }
            catch (Exception e)

            {
                return BadRequest(e);
            }

            return Ok(account);
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<Account>), 200)]
        [ProducesResponseType(typeof(void), 400)]
        public async Task<IActionResult> GetAll([FromBody] LoginDTO loginDto)
        {
            IEnumerable<Account> accounts = null;
            try
            {
                accounts = await _accountRepository.AllAsync();
            }
            catch (Exception e)

            {
                return BadRequest(e);
            }

            return Ok(accounts);
        }
    }
}
