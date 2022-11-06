using GreenSharing.API.Dtos;
using GreenSharing.API.Models;
using GreenSharing.API.Repositories;
using GreenSharing.API.Repositories.Interface;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GreenSharing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(AccountController));

        //public PasswordHasher<string> passwordHasser = new PasswordHasher<string>();        
        //MANDTORY: Contexte permet de Query la DB
        //private readonly GreenSharingContext _context;
        private readonly IAccountRepository _accountRepository;

        //MANDTORY
        public AccountController(IAccountRepository accountRepository/*, GreenSharingContext context*/)
        {
            //_context = context;
            _accountRepository = accountRepository;
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
        public async Task<IActionResult> Create([FromBody] Account account)
        {
            Account accountCreated = null;
            try
            {
                //1. Find the AccounType related
                Account accountType; //Farmer, Gleaner, BankFood

                //2. Create the Account attahcing its AccounType
                var result = await _accountRepository.CreateAsync(account);

                //3. If there is Any AccountLocation Specified and createe it
                //Creates Location if provided !

                /*
                //TODO: A FAIRE ceci est juste un exemple ! pour montrer lùtilisation direct du Contexte de la BD
                account.Password = passwordHasser.HashPassword(account.Id.ToString(), account.Password);
                account.CreationDate = DateTime.UtcNow;
                account.IsActive = true;
                account.IsEnabled = false;
                account.IsDeleted = false;

                await _context.Account.AddAsync(account);
                await _context.SaveChangesAsync();

                //Accoun-Type ? CreateGleaner(), CreateBankFood(), CreateFarmer()*/
            }
            catch (Exception e)

            {
                return BadRequest(e);
            }

            return Ok(accountCreated);
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<Account>), 200)]
        [ProducesResponseType(typeof(void), 400)]
        public async Task<IActionResult> GetAll([FromBody] LoginDTO loginDto)
        {
            IEnumerable<Account> accounts= null;
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

        // GET api/<AccountController>/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(Account), 200)]
        [ProducesResponseType(typeof(void), 400)]
        public async Task<IActionResult> GetAsync(Guid accountId)
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
    }
}
