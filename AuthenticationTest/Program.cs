using AuthenticationTest.Services;
using AuthenticationTest.Utilities;
using System;
using System.Collections.Generic;
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
                ClientId = $"292094900064-k2hgs1e504piqaa9kpp6vrsci3ibqvct.apps.googleusercontent.com",
                ClientSecret = $"24zIhAFuQBrRupVWod8gJd2Q",
                RedirectUri = "https://localhost:44353/signin-oidc",
                AuthorizationEndpoint = "https://accounts.google.com/o/oauth2/v2/auth",
                TokenEndpoint = "https://oauth2.googleapis.com/token",
                UserInfoEndpoint = "https://www.googleapis.com/oauth2/v3/userinfo"
            };

            // Initialize GoogleAuthService with Google OAuth configuration
            var _authService = new AuthorizationServiceRepo(_config);
            var userManager = new UserServiceRepo(_authService);

            // Retrieve and display user information
            var userInfo = await userManager.GetTheUserInfo();
            Console.WriteLine(userInfo);

        }
    }
}
