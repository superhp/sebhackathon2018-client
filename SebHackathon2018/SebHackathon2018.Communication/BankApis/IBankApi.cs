using SebHackathon2018.Dtos;

namespace SebHackathon2018.Communication.BankApis
{
    public interface IBankApi
    {
        string GetAuthorized(string userId);
        UserDto GetUserInfo(string token);
    }
}