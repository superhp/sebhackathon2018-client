using System;
using Microsoft.AspNetCore.Mvc;
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
            switch (bankId)
            {
                case BankEnum.Seb:
                    Redirect("Seb url");
                    break;
                case BankEnum.Swedbank:
                    Redirect("Swed url");
                    break;
            }
        }
    }
}