using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tradepro.Logic.DTOs
{
    public class ProdducStoreDto
    {
        public string StoreName { get; set; }
        public string ProductStoreName { get; set; }
        public decimal Price { get; set; }
        public int Quantity {  get; set; }
    }
}
