using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SebHackathon2018.Models;

namespace SebHackathon2018.Controllers
{
    [Route("api/Registration")]
    public class RegistrationController : Controller
    {
        [HttpPost]
        public IActionResult Register(RegistrationDto registration)
        {
            return Ok();
        }
    }
}