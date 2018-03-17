using Microsoft.AspNetCore.Mvc;
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
        [Route("api/BankView/LoginOption")]
        public void GetLoginOption(string clientId, string bankId)
        {
            Redirect("gohere");
        }
    }
}