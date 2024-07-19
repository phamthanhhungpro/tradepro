using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tradepro.Logic.Request
{
    public class StoreRequest
    {
        public string StoreName {  get; set; }
        public string Description { get; set; }
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
    }
}
