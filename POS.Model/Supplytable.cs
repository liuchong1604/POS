using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSmodel
{
    public class Supplytable
    {
        public int Code { get; set; }
        public int WarehouseId { get; set; }
        public int SupplierId { get; set; }
        public int Manager { get; set; }
        public DateTime createTime { get; set; }
    }
}
