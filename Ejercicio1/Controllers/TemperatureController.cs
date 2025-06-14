using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio1.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]
    public class TemperatureController : ControllerBase
        {
            [HttpGet("toFahrenheit")]
            public IActionResult ToFahrenheit([FromQuery] double celsius)
            {
                double fahrenheit = (celsius * 9 / 5) + 32;
                return Ok(new { fahrenheit });
            }

            [HttpGet("toCelsius")]
            public IActionResult ToCelsius([FromQuery] double fahrenheit)
            {
                double celsius = (fahrenheit - 32) * 5 / 9;
                return Ok(new { celsius });
            }
        }
    }
