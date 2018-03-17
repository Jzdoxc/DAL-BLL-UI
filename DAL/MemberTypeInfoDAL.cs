using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using MODEL;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class MemberTypeInfoDAL
    {
        public List<MemberTypeInfo> GetList()
        {
            string sql = "select * from membertypeinfo  where misdelete = 0";
            List<MemberTypeInfo> list = new List<MemberTypeInfo>();
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                MemberTypeInfo info = new MemberTypeInfo();
                info.MId = Convert.ToInt32(row[0]);
                info.MTitle = row[1].ToString();
                info.MDiscount = Convert.ToDecimal(row[2]);
                list.Add(info);
            }

            return list;
        }

        public int Insert(MemberTypeInfo mti)
        {
            //构造插入语句，注意：必须列与值相对应
            string sql = "insert into membertypeinfo(mtitle,mdiscount,misdelete) values(@title,@discount,0)";
            MySqlParameter[] ps =
            {
                new MySqlParameter("@title", mti.MTitle),
                new MySqlParameter("@discount", mti.MDiscount)
            };
            return MySqlHelper.ExecuteNonQuery(sql, ps);
        }

        public int Update(MemberTypeInfo mti)
        {
            string sql = "update membertypeinfo set mtitle=@title,mdiscount=@discount where mid=@id";
            MySqlParameter[] ps =
            {
                new MySqlParameter("@title", mti.MTitle),
                new MySqlParameter("@discount", mti.MDiscount),
                new MySqlParameter("@id", mti.MId)
            };

            return MySqlHelper.ExecuteNonQuery(sql, ps);
        }

        public int Delete(int id)
        {
            //逻辑删除，将misdelete删除标记改为1
            string sql = "update membertypeinfo set misdelete=1 where mid=@id";
            MySqlParameter ps = new MySqlParameter("@id",id);
            return MySqlHelper.ExecuteNonQuery(sql, ps);
        }

    
    }
}