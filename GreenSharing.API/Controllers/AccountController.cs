using GreenSharing.API.Dtos;
using GreenSharing.API.Models;
using Microsoft.AspNetCore.Authorization;
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
        //Contexte permet de Query la DB
        private readonly GreenSharingContext _context;

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
        [ProducesResponseType(typeof(IEnumerable<Account>), 200)]
        [ProducesResponseType(typeof(void), 400)]
        public async Task<IActionResult> All([FromBody] LoginDTO loginDto)
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
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AccountController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AccountController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
