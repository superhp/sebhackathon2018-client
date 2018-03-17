using System;
using RestSharp;
using SebHackathon2018.Db;
using SebHackathon2018.Dtos;
using SebHackathon2018.Dtos.Models;
using SebHackathon2018.Dtos.Seb;

namespace SebHackathon2018.Communication.BankApis
{
    public class IsignMobileApi : IBankApi
    {
        private string _token;
        private string _link = "https://developers.isign.io";
        private RestClient _client;

        public IsignMobileApi(string token = "test_jciCN3eqvhHitjbdsCuPECqw")
        {
            _token = token;
            _client = new RestClient(_link);
        }

        public UserDto GetUserInfo(string phone, string code)
        {
            var request = new RestRequest($"mobile/login.json?access_token={_token}", Method.POST);

            request.RequestFormat = DataFormat.Json;
            request.AddBody(new
            {
                phone = "+" + phone,
                code
            });

            var response = _client.Execute<Dtos.iSign.UserInfoDto>(request);

            var userInfo = response.Data;

            return new UserDto
            {
                Citizenship = userInfo.country,
                Email = "",
                FullName = userInfo.name + " " + userInfo.surname,
                Id = userInfo.code
            };
        }

        public AccessTokenDto GetAuthorized(string userId)
        {
            var request = new RestRequest($"mobile/login.json?access_token={_token}", Method.POST);

            var info = userId.Split(',');

            request.RequestFormat = DataFormat.Json;
            request.AddBody(new
            {
                phone = "+" + info[0],
                code = "" + info[1]
            });

            var response = _client.Execute<Dtos.iSign.UserInfoDto>(request);

            var userInfo = response.Data;

            return new AccessTokenDto
            {
                BankId = BankEnum.MobileSign,
                BankToken = userInfo.token,
                Expires = userInfo.certificate.valid_to.ToString(),
                Token = Guid.NewGuid().ToString(),
                User = new UserDto
                {
                    Citizenship = userInfo.country,
                    Email = "",
                    FullName = userInfo.name + " " + userInfo.surname,
                    Id = userInfo.code
                }
            };
        }

        public UserDto GetUserInfo(AccessTokenDto token)
        {
            var tokenDto = TokensRepository.Get(token.Token);

            return tokenDto.User;
        }
    }
}