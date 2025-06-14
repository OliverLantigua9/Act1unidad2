using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorController : ControllerBase
    {
        [HttpGet("add")]
        public IActionResult Add([FromQuery] double a, [FromQuery] double b)
            => Ok(new { result = a + b });

        [HttpGet("subtract")]
        public IActionResult Subtract([FromQuery] double a, [FromQuery] double b)
            => Ok(new { result = a - b });

        [HttpGet("multiply")]
        public IActionResult Multiply([FromQuery] double a, [FromQuery] double b)
            => Ok(new { result = a * b });

        [HttpGet("divide")]
        public IActionResult Divide([FromQuery] double a, [FromQuery] double b)
        {
            if (b == 0)
                return BadRequest(new { error = "No se puede dividir entre cero." });

            return Ok(new { result = a / b });
        }
    }
}
