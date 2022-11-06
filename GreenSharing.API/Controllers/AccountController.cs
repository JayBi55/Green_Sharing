using GreenSharing.API.Dtos;
using GreenSharing.API.Models;
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

        public PasswordHasher<string> passwordHasser = new PasswordHasher<string>();

        //MANDTORY: Contexte permet de Query la DB
        private readonly GreenSharingContext _context;

        //MANDTORY
        public AccountController(GreenSharingContext context)
        {
            _context = context;
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(LoginDTO), 200)]
        [ProducesResponseType(typeof(void), 400)]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
        {
            try
            {
                //TODO: Logique de Login
               
            }
            catch (Exception e)

            {
                return BadRequest(e);
            }

            return Ok(loginDto);
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(Account), 200)]
        [ProducesResponseType(typeof(void), 400)]
        public async Task<IActionResult> Create([FromBody] Account account)
        {
            try
            {
                //TODO: A FAIRE ceci est juste un exemple ! pour montrer lùtilisation direct du Contexte de la BD
                account.Password = passwordHasser.HashPassword(account.Id.ToString(), account.Password);
                account.CreationDate = DateTime.UtcNow;
                account.IsActive = true;
                account.IsEnabled = false;
                account.IsDeleted = false;

                await _context.Account.AddAsync(account);
                await _context.SaveChangesAsync();
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
            var accounts = new List<Account>();
            try
            {
                accounts = await _context.Account.ToListAsync();
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
                account = await _context.Account.FirstOrDefaultAsync(x => x.Id == accountId);
            }
            catch (Exception e)

            {
                return BadRequest(e);
            }

            return Ok(account);
        }
    }
}
