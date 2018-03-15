using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace DAL
{
   public static class MySqlHelper
    {
        private static string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

        public static DataTable GetList (string sql, params MySqlParameter[] ps)
        {
            //构造连接对象
            using (MySqlConnection conn =new MySqlConnection(connStr))
            {
                //构造桥接器对象
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
                //增加参数
             
                    adapter.SelectCommand.Parameters.AddRange(ps);
           
                //数据表对象
                DataTable dt = new DataTable();
                //填充数据表
                adapter.Fill(dt);
                //返回数据表
                return dt;
            }
        }


        public static int ExecuteNonQuery(string sql,params MySqlParameter[] ps)
        {
            using (MySqlConnection con = new MySqlConnection(connStr))
            {
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddRange(ps);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
