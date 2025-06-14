using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TuProyecto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UnitsController : ControllerBase
    {
        [HttpGet("convert")]
        public IActionResult Convert(string from, string to, double value)
        {
            double result;

            if (from == "km" && to == "miles") result = value * 0.621371;
            else if (from == "miles" && to == "km") result = value / 0.621371;
            else if (from == "lbs" && to == "kg") result = value * 0.453592;
            else if (from == "kg" && to == "lbs") result = value / 0.453592;
            else return BadRequest("Conversión no válida.");

            return Ok(new { result });
        }
    }
}