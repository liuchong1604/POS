using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

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
            List<string> values = new List<string>();

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
        
        public static List<T> GetAll()
        {
            List<T> list = new List<T>();
            string table = typeof(T).Name;

            Assembly ass = Assembly.GetAssembly(typeof(T));
            PropertyInfo[] pis = typeof(T).GetProperties();
            
            string sqlStr = $"select * from {table}";

            DataSet ds = DbHelper.ExecuteAdapter(sqlStr);
            
            foreach(DataRow row in ds.Tables[0].Rows)
            {
                object o = ass.CreateInstance(typeof(T).FullName);
                foreach(var pi in pis){
                    if (pi.PropertyType.Equals(typeof(Int32))){
                        pi.SetValue((T)o, Convert.ToInt32(row[pi.Name], null));
                    }
                    else if(pi.PropertyType.Equals(typeof(string))){
                        pi.SetValue((T)o, Convert.ToString(row[pi.Name]), null);
                        
                    }else if (pi.PropertyType.Equals(typeof(Decimal)))
                    {
                        pi.SetValue((T)o, Convert.ToDecimal(row[pi.Name]), null);
                    }
                }
                list.Add((T)o);
            }
            return list;
        } 
    }
}
