using SebHackathon2018.Dtos.Models;

namespace SebHackathon2018.Dtos
{
    public class AccessTokenDto
    {
        public string BankToken { get; set; }
        public string Token { get; set; } 
        public BankEnum BankId { get; set; }
        public UserDto User { get; set; }
        public string Expires { get; set; }
    }
}