// Controllers/WelcomeController.cs

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.NetworkInformation;
using System.Text;

namespace Ejercicio1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WelcomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetWelcomeMessage(string name)
        {
            return Ok(string.Format("¡Hola {0}! Bienvenido a mi API", name));
        }
    }
}

// Controllers/CalculatorController.cs

[ApiController]
[Route("api/[controller]")]
public class CalculatorController : ControllerBase
{
    [HttpGet("add")]
    public IActionResult Add(double a, double b) => Ok(new { result = a + b });

    [HttpGet("subtract")]
    public IActionResult Subtract(double a, double b) => Ok(new { result = a - b });

    [HttpGet("multiply")]
    public IActionResult Multiply(double a, double b) => Ok(new { result = a * b });

    [HttpGet("divide")]
    public IActionResult Divide(double a, double b)
    {
        if (b == 0) return BadRequest("División por cero no permitida");
        return Ok(new { result = a / b });
    }
}

// Controllers/TemperatureController.cs

[ApiController]
[Route("api/[controller]")]
public class TemperatureController : ControllerBase
{
    [HttpGet("toFahrenheit")]
    public IActionResult ToFahrenheit(double celsius)
    {
        double fahrenheit = (celsius * 9 / 5) + 32;
        return Ok(new { fahrenheit });
    }

    [HttpGet("toCelsius")]
    public IActionResult ToCelsius(double fahrenheit)
    {
        double celsius = (fahrenheit - 32) * 5 / 9;
        return Ok(new { celsius });
    }
}

// Controllers/CurrencyController.cs

namespace Ejercicio1.Controllers
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

//UnitsController.cs

namespace Ejercicio1.Controllers
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

//PasswordController.cs

namespace Ejercicio1.Controllers
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

//RandomController.cs

namespace Ejercicio1.Controllers
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

//PalindromeController.cs

namespace Ejercicio1.Controllers
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

//AgeController.cs

namespace Ejercicio1.Controllers
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