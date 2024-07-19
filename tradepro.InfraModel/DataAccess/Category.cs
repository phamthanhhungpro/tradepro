using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace tradepro.InfraModel.DataAccess
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }
        public ICollection<Product>   Products { get; set; }

    }
}
