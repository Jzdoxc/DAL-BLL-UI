using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace DAL
{
    public class MemberTypeInfoDAL
    {
        public List<MemberTypeInfo> GetList()
        {
            string sql = "select * from membertypeinfo  where misdelete = 0"; 
            List<MemberTypeInfo> list = new List<MemberTypeInfo>();
            MemberTypeInfo info = new MemberTypeInfo();
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql,ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                info.MId = Convert.ToInt32(row[0]);
                info.MTitle = row[1].ToString();
                info.MDiscount = Convert.ToDecimal(row[2]);
                info.MIsDelete = Convert.ToBoolean(row[3]);
                list.Add(info);
            }
                return list;



        }
          
    }
    }
