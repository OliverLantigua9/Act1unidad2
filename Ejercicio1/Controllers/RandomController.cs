using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TuProyecto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RandomController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(int min, int max)
        {
            if (min >= max) return BadRequest("El valor mínimo debe ser menor al máximo.");

            var random = new Random();
            int number = random.Next(min, max + 1);

            return Ok(new { randomNumber = number });
        }
    }
}