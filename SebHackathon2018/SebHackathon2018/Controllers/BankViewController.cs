using System;
using Microsoft.AspNetCore.Mvc;
using SebHackathon2018.Communication.BankApis;
using SebHackathon2018.Db;
using SebHackathon2018.Models;

namespace SebHackathon2018.Controllers
{
    [Route("api/BankView")]
    public class BankViewController : Controller
    {
        [HttpGet]
        [Route("{clientId}")]
        public BankViewDto GetLoginView(string clientId)
        {
            if (clientId != "our-happy-client")
            {
                throw new Exception("Unauthorized");
            }

            var staticTemplate = System.Text.Encoding.Default.GetString(Properties.Resources.BankView);
            var bankViewTemplate = staticTemplate.Replace("clientId", clientId);

            return new BankViewDto
            {
                BankViewTemplate = bankViewTemplate
            };
        }

        [HttpGet]
        [Route("LoginOption/{clientId}/{bankId}")]
        public void GetLoginOption(string clientId, BankEnum bankId)
        {
            // TODO: do something with clientId and bankId
            var userId = "ibsUser1";
            switch (bankId)
            {
                case BankEnum.Seb:
                    //should differ from swed
                    Redirect($"http://localhost:61392/api/Auth/Callback/{bankId}/{userId}");
                    break;
                case BankEnum.Swedbank:
                    //should differ from seb
                    Redirect($"http://localhost:61392/api/Auth/Callback/{bankId}/{userId}");
                    break;
                default:
                    throw new Exception("No more banks are supported");
            }
        }

        [HttpGet]
        [Route("UserInfo/{accessToken}")]
        public IActionResult GetUserInfo(string accessToken)
        {
            IBankApi bankApi = new SebApi();

            var tokenDto = TokensRepository.Get(accessToken);

            if (tokenDto == null)
                throw new Exception("Invalid token");

            var userInfo = bankApi.GetUserInfo(tokenDto.BankToken);

            return Ok(userInfo);
        }
    }
}