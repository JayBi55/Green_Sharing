using GreenSharing.API.Dtos;
using GreenSharing.API.Extensions;
using GreenSharing.API.Repositories.DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenSharing.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(Account), 200)]
        [ProducesResponseType(typeof(void), 400)]
        public async Task<IActionResult> MapAccount([FromBody] AccountDTO accountDto)
        {
            Account account = null;
            try
            {
                //TODO
                account = accountDto.ToEntity<AccountDTO, Account>();
            }
            catch (Exception e)

            {
                return BadRequest(e);
            }

            return Ok(account);
        }
    }
}
