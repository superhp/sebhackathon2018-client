using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SebHackathon2018.Db;
using SebHackathon2018.Dtos;
using System;
using SebHackathon2018.Dtos.Models;

namespace SebHackathon2018.Controllers
{
    [Route("api/[controller]")]
    public class RegistrationController : Controller
    {
        [HttpPost]
        public IActionResult Register([FromBody]RegistrationDto registration)
        {
            var customer = new CustomerDto()
            {
                ClientId = Guid.NewGuid(),
                CompanyName = registration.CompanyName,
                RedirectUrl = registration.RedirectUrl
            };
            CustomersRepository.Add(customer);
            return CreatedAtRoute(new { customer.ClientId }, customer);
        }

        [HttpGet("{clientId}")]
        public CustomerDto Get(string clientId)
        {
            return CustomersRepository.Get(clientId);
        }
    }
}