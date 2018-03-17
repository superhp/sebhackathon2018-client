using Microsoft.AspNetCore.Mvc;

namespace SebHackathon2018.Controllers
{
    [Route("api/BankView")]
    public class BankViewController : Controller
    {
        [HttpGet]
        public string GetLoginView()
        {
            var result = System.Text.Encoding.Default.GetString(Properties.Resources.BankView);
            return result;
        }

        [HttpGet]
        [Route("api/BankView/LoginOption")]
        public void GetLoginOption(string clientId, string bankId)
        {
            Redirect("gohere");
        }
    }
}