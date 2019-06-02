using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.API.ViewModels.Identity
{
    public class AuthenticatedVM
    {
        public UserVM User { get; set; }
        public string Token { get; set; }
        public bool RememberMe { get; set; }
    }
}
