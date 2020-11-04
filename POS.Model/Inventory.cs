using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSmodel
{
    public class Inventory
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public int GoodsCount { get; set; }
        public int WareHouseCode { get; set; }
        public int Category { get; set; }
    }
}
