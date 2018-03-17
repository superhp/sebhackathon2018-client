using SebHackathon2018.Dtos;

namespace SebHackathon2018.Communication.BankApis
{
    public interface IBankApi
    {
        AccessTokenDto GetAuthorized(string userId);
        UserDto GetUserInfo(AccessTokenDto token);
    }
}