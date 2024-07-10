using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tradepro.Logic.Request
{
    public class ChangpasswordRequest
    {
        public string Oldpassword {  get; set; }
        public string Newpassword { get; set; }
    }
}
