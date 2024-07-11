using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tradepro.Logic.DTOs
{
    public class LoginResponse
    {
        public string Email { get; set; }
        public Guid UserId { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}
