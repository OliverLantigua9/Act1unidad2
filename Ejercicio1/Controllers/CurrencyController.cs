using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TuProyecto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurrencyController : ControllerBase
    {
        [HttpGet("convert")]
        public IActionResult Convert(double amount, string from, string to)
        {
            double rate = 1.0;

            if (from == to)
                return Ok(new { result = amount });

            // Tasa fija simulada (sin API real)
            if (from == "USD" && to == "EUR") rate = 0.85;
            else if (from == "EUR" && to == "USD") rate = 1.18;
            else if (from == "USD" && to == "DOP") rate = 58;
            else if (from == "DOP" && to == "USD") rate = 0.017;
            else if (from == "EUR" && to == "DOP") rate = 63;
            else if (from == "DOP" && to == "EUR") rate = 0.016;
            else return BadRequest("Conversión no soportada.");

            double result = amount * rate;
            return Ok(new { result });
        }
    }
}
