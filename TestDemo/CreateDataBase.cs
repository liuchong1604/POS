using POSmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDemo
{
    /// <summary>
    /// 创建插入类的对象
    /// </summary>
    class CreateDataBase
    {
        public static void CreateStore(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Store store = new Store
                {
                    Code = i,
                    Name = $"第{i + 1}号商店",
                    Address = $"深圳市第{new Random(i + 1).Next(1, 100)}街道 {new Random(i).Next(1, 50)}号",
                    Manager = 1,
                    WarehouseCode = i
                };
                DBManager<Store>.Add(store);
            }
        }
    }
}
