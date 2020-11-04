using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSmodel
{
    public class GoodsHub
    {
        public int WarehouseCode { get; set; }
        public int GoodsId { get; set; }
        public decimal GoodsCost { get; set; }
        public int GoodsCount { get; set; }
    }
}
