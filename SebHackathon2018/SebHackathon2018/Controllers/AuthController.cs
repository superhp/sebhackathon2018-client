using System;
using Microsoft.AspNetCore.Mvc;
using SebHackathon2018.Communication;
using SebHackathon2018.Communication.BankApis;
using SebHackathon2018.Db;
using SebHackathon2018.Dtos;
using SebHackathon2018.Dtos.Models;

namespace SebHackathon2018.Controllers
{
    [Route("api/Auth")]
    public class AuthController : Controller
    {
        [HttpGet]
        [Route("Callback/{bankId}/{userId}")]
        public IActionResult GetRedirectFromBank(BankEnum bankId, string userId)
        {
            IBankApi bankApi;

            switch (bankId)
            {
                case BankEnum.Seb:
                    //should differ from swed
                    bankApi = new SebApi();
                    break;
                case BankEnum.MobileSign:
                   bankApi = new IsignMobileApi();
                    break;
                default:
                    throw new Exception("Bank not supported");
            }

            var tokenDto = bankApi.GetAuthorized(userId);

            TokensRepository.Add(tokenDto);

            return Redirect($"http://localhost:3000/link?token={tokenDto.Token}");
        }
    }
}