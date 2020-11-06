using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDemo
{
    /// <summary>
    /// 执行对应的SQL语句
    /// </summary>
    public abstract class DbHelper
    {
        public static string SqlConn = "Data Source=192.168.10.1;Initial Catalog=sysobjects;Persist Security Info=True;User ID=sa;Password=123456";

        /// <summary>
        /// 执行普通的SQL语句,返回是否执行成功
        /// </summary>
        /// <param name="SqlStr"></param>
        /// <returns></returns>
        public static bool ExceuteNon(string SqlStr)
        {
            bool flag = false;
            using (SqlConnection conn = new SqlConnection(SqlConn))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                using (SqlCommand cmd = new SqlCommand(SqlStr, conn))
                {
                    try
                    {
                        int raw = cmd.ExecuteNonQuery();
                        if (raw > 0)
                        {
                            flag = true;
                        }
                        else
                        {
                            flag = false;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"错误信息:{e.Message}");
                    }
                }
            }
            return flag;
        }

        public static DataSet ExecuteAdapter(string SqlStr)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(SqlConn))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                using (SqlCommand cmd = new SqlCommand(SqlStr, conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds);
                }
            }
            return ds;
        }
    }
}
