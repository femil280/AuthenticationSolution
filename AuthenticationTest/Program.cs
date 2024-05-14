using AuthenticationTest.Services;
using AuthenticationTest.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AuthenticationTest
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // Google OAuth configuration
            var _config = new AuthConfig
            {
                MyCId = ConfigurationManager.AppSettings["CId"],
                MyCS = ConfigurationManager.AppSettings["CS"],
                RedirectUri = "http://localhost:8899/callback",
                AuthorizationEndpoint = "https://accounts.google.com/o/oauth2/v2/auth",
                TokenEndpoint = "https://oauth2.googleapis.com/token",
                UserInfoEndpoint = "https://www.googleapis.com/oauth2/v3/userinfo"
            };

            // Initialize GoogleAuthService with Google OAuth configuration
            var _authService = new AuthorizationServiceRepo(_config);
            var userManager = new UserServiceRepo(_authService, _config);

            // Retrieve and display user information
            var userInfo = await userManager.GetTheUserInfo();
            Console.WriteLine(userInfo);

        }
    }
}
