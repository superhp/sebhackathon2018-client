using System;
using Microsoft.AspNetCore.Mvc;
using SebHackathon2018.Communication;
using SebHackathon2018.Communication.BankApis;
using SebHackathon2018.Db;
using SebHackathon2018.Dtos;

namespace SebHackathon2018.Controllers
{
    [Route("api/Auth")]
    public class AuthController : Controller
    {
        [HttpGet]
        [Route("Callback/{bankId}/{userId}")]
        public IActionResult GetRedirectFromBank(string bankId, string userId)
        {
            IBankApi bankApi = new SebApi();

            var token = bankApi.GetAuthorized(userId);

            var tokenDto = new AccessTokenDto
            {
                BankToken = token,
                Token = Guid.NewGuid().ToString()
            };

            TokensRepository.Add(tokenDto);

            return Redirect($"http://localhost:61392/link?token={tokenDto.Token}");
        }
    }
}