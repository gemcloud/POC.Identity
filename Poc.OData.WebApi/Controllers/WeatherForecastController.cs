using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Poc.OData.WebApi.DTOs;

namespace Poc.OData.WebApi.Controllers
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
        [SwaggerOperation("GetAllWeatherForecast")]
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
        [Produces("application/json")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(List<AddressDto>), (int)HttpStatusCode.OK)]
        [SwaggerOperation("GetAllAdresses")]
        //public IActionResult PostDemo()
        public async Task<ActionResult> GetAllAsync()
        {
            return Ok(new { Token = "asdadasfafsd" });
        }

        [HttpGet]
        [Route("api/weatherForecast/GetAllDemoAsync")]
        //[Produces("application/json")]
        //[ProducesResponseType((int)HttpStatusCode.NotFound)]
        //[ProducesResponseType(typeof(List<AddressDto>), (int)HttpStatusCode.OK)]
        [SwaggerOperation(summary: "Get entity from Category by key", OperationId = "GetCategoryById")]
        public async Task<ActionResult> GetAllDemoAsync()
        {
            // ....

            //return Json(new { status = false, message = "Invalid Email!" });
            return Ok(new { Token = "asdadasfafsd" });
        }


        //public async Task<ActionResult> Validate()
        //{
        //    return Json(new { status = true, message = "Login Successfull!" });
        //}


    }
}
