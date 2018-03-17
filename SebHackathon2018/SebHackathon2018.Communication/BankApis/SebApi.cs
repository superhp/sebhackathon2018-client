using System;
using RestSharp;
using SebHackathon2018.Dtos;
using SebHackathon2018.Dtos.Models;
using SebHackathon2018.Dtos.Seb;

namespace SebHackathon2018.Communication.BankApis
{
    public class SebApi : IBankApi
    {
        private string _tppToken;
        private RestClient _client;
        private string _link = "https://test.api.ob.baltics.sebgroup.com";
        private string _bic = "EEUHEE2X";

        public SebApi(string tppToken = "eyJhbGciOiJIUzUxMiJ9.eyJzdWIiOiJsYXVyeW5hc3NpbUBnbWFpbC5jb20tVFBQVE9LRU4tMSIsImV4cCI6MTU1Mjc2NjQ1NH0.KA_lPuOHT6PWwuh949INKJXTrBKk1ao51pweFKVGyGT6tZfqhZq5dmreDTMSlyviJ05g7cLJIgLvQIIEvAw4jQ")
        {
            _tppToken = tppToken;

            _client = new RestClient(_link);
        }

        private AuthorizationFirstStepDto StartAuthorization(string userId)
        {
            var request = new RestRequest($"v1/user/authorization?bic={_bic}", Method.POST);

            request.RequestFormat = DataFormat.Json;
            request.AddBody(new
            {
                ibsUserId = userId
            });

            //request.AddParameter("bic", "CBVILT2X");

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Tpp-token", _tppToken);

            var response = _client.Execute<AuthorizationFirstStepDto>(request);

            return response.Data;
        }

        public AuthorizationDto Authorize(string userId, AuthorizationFirstStepDto authInfo)
        {
            var request = new RestRequest($"v1/user/authorization/{authInfo.AuthorizationKey}/token", Method.POST);

            request.RequestFormat = DataFormat.Json;
            request.AddBody(new
            {
                ibsUserId = userId,
                period = "month"
            });

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Tpp-token", _tppToken);

            var response = _client.Execute<AuthorizationDto>(request);

            return response.Data;
        }

        public AccessTokenDto GetAuthorized(string userId)
        {
            var authorization = StartAuthorization(userId);
            var authorizeDto = Authorize(userId, authorization);

            return new AccessTokenDto
            {
                BankToken = authorizeDto.Token,
                Token = Guid.NewGuid().ToString(),
                BankId = BankEnum.Seb,
                Expires = authorizeDto.Expires
            };
        }

        public UserDto GetUserInfo(AccessTokenDto token)
        {
            var request = new RestRequest($"v1/bics/{_bic}/customer", Method.GET);

            request.RequestFormat = DataFormat.Json;

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Tpp-token", _tppToken);
            request.AddHeader("User-Token", token.BankToken);

            var response = _client.Execute<UserInfoDto>(request);

            return new UserDto
            {
                Citizenship = response.Data.citizenship,
                Email = response.Data.email,
                FullName = response.Data.customerName,
                Id = response.Data.registrationCode
            };
        }
    }
}