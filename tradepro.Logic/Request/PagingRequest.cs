using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tradepro.Logic.Request
{
    public class PagingRequest
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
