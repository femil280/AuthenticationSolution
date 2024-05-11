using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationTest.Services
{
    public interface IUserService
    {
        Task<string> GetTheUserInfo();
    }
}
