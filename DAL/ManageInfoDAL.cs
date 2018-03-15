using MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Common;

namespace DAL
{
    public class ManageInfoDAL
    {
        public List<ManagerInfo> GetList(ManagerInfo mi)
        {
            string sql= "select * from managerinfo";
            MySqlParameter[] ps = new MySqlParameter[2] ;
            //拼接查询条件
            if (mi!=null)
            {
                sql += "  where mname=@name and mpwd=@pwd";
                ps[0] = new MySqlParameter("@name", mi.MName);
                ps[1]=new MySqlParameter("@pwd",MD5Helper.GetMd5( mi.MPwd));
            }
            //执行查询，获取数据
            DataTable dt = MySqlHelper.GetList(sql,ps);
            //构造集合对象
            List<ManagerInfo> list = new List<ManagerInfo>();
            //遍历数据表中的行，将数据转存到LIST
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new ManagerInfo()
                {
                    MId = Convert.ToInt32(row["MId"]),
                    MName = row["mname"].ToString(),
                    MPwd = row["mpwd"].ToString(),
                    MType = Convert.ToInt32(row["mtype"])
                });
            }
            return list;
        }

        public int DeleteById(int id)
        {
            string sql = "delete  from managerinfo where  mid = @id";
            MySqlParameter ps = new MySqlParameter("@id", id);
           return  MySqlHelper.ExecuteNonQuery(sql,ps);
        }

        public int Insert(ManagerInfo mi)
        {
            string sql = "insert into managerinfo(mname,mpwd,mtype) values(@name,@pwd,@type)";
            MySqlParameter[] ps =
            {
                new MySqlParameter("@name",mi.MName),
                new MySqlParameter("@pwd",MD5Helper.GetMd5(mi.MPwd)),
                new MySqlParameter("@type",mi.MType)
            };
            return MySqlHelper.ExecuteNonQuery(sql, ps);
        }
        public int Update(ManagerInfo mi)
        {
           List< MySqlParameter> ps = new List<MySqlParameter>();
            string sql = "update  managerinfo set  mname=@name,";
            if (!mi.MPwd.Equals("******"))
            {
                sql +="mpwd=@pwd,";
                ps.Add(new MySqlParameter("@pwd", MD5Helper.GetMd5(mi.MPwd)));
            }
                sql+= " mtype=@type where mid=@id";
           ps .AddRange(new MySqlParameter[]{
                new MySqlParameter("@name", mi.MName),
                new MySqlParameter("@type", mi.MType),
                new MySqlParameter("@id",mi.MId)
            });
            return MySqlHelper.ExecuteNonQuery(sql, ps.ToArray());
        }
    }
}
