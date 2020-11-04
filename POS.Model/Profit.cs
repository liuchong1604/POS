using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSmodel
{
    public class Profit
    {
        public int GoodsCode { get; set; }
        public string GoodsName { get; set; }
        public decimal GoodsCost { get; set; }
        public decimal GoodsPrice { get; set; }
        public DateTime createTime { get; set; }
    }
}
