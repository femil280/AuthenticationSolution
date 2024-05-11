using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationTest.Services
{
    public interface IAuthorizationService
    {
        Task<string> GetAuthorizationCode();
        Task<string> GetToken(string authorizationCode);
    }
}
