using System;
using Microsoft.AspNetCore.Mvc;
using SebHackathon2018.Communication.BankApis;
using SebHackathon2018.Db;
using SebHackathon2018.Dtos.Models;

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
        public IActionResult GetLoginOption(string clientId, BankEnum bankId)
        {
            // TODO: do something with clientId and bankId
            var userId = "ibsUser1";
            switch (bankId)
            {
                case BankEnum.Seb:
                    //should differ from swed
                    return Redirect($"http://localhost:61392/api/Auth/Callback/{bankId}/{userId}");
                case BankEnum.Swedbank:
                    //should differ from seb
                    return Redirect($"http://localhost:61392/api/Auth/Callback/{bankId}/{userId}");
                default:
                    throw new Exception("Bank not supported");
            }
        }

        [Route("LoginMobile/{clientId}/{phone}/{code}")]
        public IActionResult GetLoginMobile(string phone, string code)
        {
            var userId = phone + "," + code;
            return Redirect($"http://localhost:61392/api/Auth/Callback/{BankEnum.MobileSign}/{userId}");
        }

        [HttpGet]
        [Route("UserInfo/{accessToken}")]
        public IActionResult GetUserInfo(string accessToken)
        {
            var tokenDto = TokensRepository.Get(accessToken);

            if (tokenDto == null)
                throw new Exception("Invalid token");

            IBankApi bankApi;

            switch (tokenDto.BankId)
            {
                case BankEnum.Seb:
                    bankApi = new SebApi();
                    break;
                case BankEnum.MobileSign:
                    bankApi = new IsignMobileApi();
                    break;
                default:
                    throw new Exception("Bank not supported");
            }

            var userInfo = bankApi.GetUserInfo(tokenDto);

            return Ok(userInfo);
        }
    }
}