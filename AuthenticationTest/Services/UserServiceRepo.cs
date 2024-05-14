using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AuthenticationTest.Utilities;

namespace AuthenticationTest.Services
{
    public class UserServiceRepo:IUserService
    {
        private readonly IAuthorizationService _authService;
        private readonly AuthConfig _config;
        public UserServiceRepo(IAuthorizationService userService, AuthConfig config)
        {
            _authService = userService;
            _config = config;
        }
        public async Task<string> GetTheUserInfo()
        {
            var authorizationCode =await _authService.GetAuthorizationCode();
            var accessToken =await _authService.GetToken(authorizationCode);

            // Retrieve user info using access token
            if (accessToken != null) 
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                var response = client.GetAsync(_config.UserInfoEndpoint);
                return response.Result.ToString();
            }
            return accessToken;
        }
    }
}
