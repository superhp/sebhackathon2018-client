using System.Collections.Generic;
using System.Linq;
using SebHackathon2018.Dtos;

namespace SebHackathon2018.Db
{
    public static class TokensRepository
    {
        private static List<AccessTokenDto> _accessTokenDtos = new List<AccessTokenDto>();

        public static void Add(AccessTokenDto token)
        {
            _accessTokenDtos.Add(token);
        }

        public static AccessTokenDto Get(string token)
        {
            return _accessTokenDtos.FirstOrDefault(t => t.Token.Equals(token));
        }
    }
}