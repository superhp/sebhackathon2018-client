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
        public BankViewDto GetLoginView()
        {
            var result = System.Text.Encoding.Default.GetString(Properties.Resources.BankView);
            return new BankViewDto
            {
                BankViewTemplate = result
            };
        }

        [HttpGet]
        [Route("LoginOption/{cliendId}/{bankId}")]
        public IActionResult GetLoginOption(string clientId, string bankId)
        {
            // TODO: do something with clientId and bankId

            var userId = "ibsUser1";

            return Redirect($"http://localhost:61392/api/Auth/Callback/{bankId}/{userId}");
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