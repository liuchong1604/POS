using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSmodel
{
    public class SellingDetaill
    {
        public int TableId { get; set; }
        public int GoodsId { get; set; }
        public string GoodsName { get; set; }
        public decimal GoodsPrice { get; set; }
        public int Code { get; set; }
    }
}
