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

