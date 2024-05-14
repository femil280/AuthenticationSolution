using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationTest.Utilities
{
    public class AuthConfig
    {
        public string MyCId { get; set; }
        public string MyCS { get; set; }
        public string RedirectUri { get; set; }
        public string AuthorizationEndpoint { get; set; }
        public string TokenEndpoint { get; set; }
        public string UserInfoEndpoint { get; set; }
    }
}
