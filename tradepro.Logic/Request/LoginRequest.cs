using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tradepro.Logic.Request
{
    public class LoginRequest
    {
        public string UserNameOrPhone { get; set; }
        public string Password { get; set; }
    }
}
