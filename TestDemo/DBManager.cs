using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDemo
{
    /// <summary>
    /// 创建SQL语句
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DBManager<T>
    {
        /// <summary>
        /// 添加商店信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Add(T model)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string table = typeof(T).Name;

            List<string> parames = new List<string>();
            List<String> values = new List<string>();

            var props = model.GetType().GetProperties();
            foreach(var prop in props)
            {
                parames.Add(prop.Name);
                if (prop.PropertyType.Name.Equals("String"))
                {
                    values.Add("'" + prop.GetValue(model).ToString() + "'");
                }
                else
                {
                    values.Add(prop.GetValue(model).ToString());
                }
            }
            string sql = $"insert into {table} ({string.Join(",", parames)}) values ({string.Join(",", values)})";
            return DbHelper.ExceuteNon(sql);
        }
        
    }
}
