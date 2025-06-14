using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TuProyecto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgeController : ControllerBase
    {
        [HttpGet("calculate")]
        public IActionResult Calculate([FromQuery] DateTime birthDate)
        {
            var today = DateTime.Today;
            int age = today.Year - birthDate.Year;

            if (birthDate.Date > today.AddYears(-age)) age--;

            return Ok(new { age });
        }
    }
}
