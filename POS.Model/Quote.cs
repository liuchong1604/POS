using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSmodel
{
    public class Quote
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public int Category { get; set; }
        public decimal GoodsPrice { get; set; }
        public int StoreCode { get; set; }
    }
}
