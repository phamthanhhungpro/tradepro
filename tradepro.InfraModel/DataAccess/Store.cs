using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tradepro.InfraModel.DataAccess
{
    public class Store : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }
        public IEnumerable<ProductStore> productStores { get; set; }
    }
}
