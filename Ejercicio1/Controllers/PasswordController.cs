using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace TuProyecto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PasswordController : ControllerBase
    {
        [HttpGet("generate")]
        public IActionResult Generate(int length, bool includeSymbols)
        {
            if (length <= 0) return BadRequest("Longitud inválida.");

            var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var symbols = "!@#$%^&*()_+-=[]{}|;:,.<>?";
            if (includeSymbols) chars += symbols;

            var random = new Random();
            var sb = new StringBuilder();

            for (int i = 0; i < length; i++)
                sb.Append(chars[random.Next(chars.Length)]);

            return Ok(new { password = sb.ToString() });
        }
    }
}