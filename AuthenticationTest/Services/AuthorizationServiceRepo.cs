using AuthenticationTest.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace AuthenticationTest.Services
{
    public class AuthorizationServiceRepo: IAuthorizationService
    {
        private readonly AuthConfig _config;
        public AuthorizationServiceRepo(AuthConfig config)
        {
            _config = config;
        }
        public async Task<string> GetAuthorizationCode()
        {
            await Task.Delay(1000); // 1 second delay
            var authorizationUrl = $"{_config.AuthorizationEndpoint}?client_id={_config.MyCId}&redirect_uri={_config.RedirectUri}&response_type=code&scope=email%20profile";
            Console.WriteLine($"Please authorize the application by visiting: {authorizationUrl}");
            Console.WriteLine("After granting permissions, please enter the authorization code: you see on your browser and hit enter" );

            var authorizationCode = Console.ReadLine();
            return authorizationCode;
         
        }
        public async Task<string> GetToken(string authorizationCode)
        {
            // Exchange authorization code for access token
            var client = new HttpClient();
            var tokenRequest = new HttpRequestMessage(HttpMethod.Post, _config.TokenEndpoint);
            tokenRequest.Content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("client_id", _config.MyCId),
                new KeyValuePair<string, string>("client_secret", _config.MyCS),
                new KeyValuePair<string, string>("code", authorizationCode),
                new KeyValuePair<string, string>("grant_type", "authorization_code"),
                new KeyValuePair<string, string>("redirect_uri", _config.RedirectUri)
            });

            var response =await client.SendAsync(tokenRequest);
            var responseContent = await response.Content.ReadAsStringAsync();
            var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(responseContent);

            return tokenResponse.AccessToken;
        }
    }
}
