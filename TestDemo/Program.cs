using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateDataBase.CreateStore(10);

            DataSet ds = DbHelper.ExecuteAdapter("Select * from Store");
            foreach(DataRow row in ds.Tables[0].Rows)
            {
                Console.WriteLine(row["Name"]+" " + row["ADDRESS"]);
            }
            Console.WriteLine(Convert.ToInt32((DateTime.Now - new DateTime(2000, 1, 1, 8, 0, 0)).TotalSeconds));
            Console.ReadLine();
        }
    }
}
