using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tradepro.InfraModel.DataAccess
{
    public class ProductStore : BaseEntity
    {
        public string Name { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
        public Store Store { get; set; }
    }
}
