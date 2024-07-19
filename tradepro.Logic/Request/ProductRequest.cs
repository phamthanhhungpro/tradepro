using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tradepro.InfraModel.DataAccess;

namespace tradepro.Logic.Request
{
    public class ProductRequest
    {
        public string ProductName {  get; set; }
        public Guid CategoryId { get; set; }
    }
}
