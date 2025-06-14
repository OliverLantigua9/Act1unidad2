using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TuProyecto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PalindromeController : ControllerBase
    {
        [HttpGet("check")]
        public IActionResult Check([FromQuery] string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return BadRequest("Texto inválido.");

            var reversed = new string(text.Reverse().ToArray());
            bool isPalindrome = text.Equals(reversed, StringComparison.OrdinalIgnoreCase);

            return Ok(new { text, isPalindrome });
        }
    }
}
