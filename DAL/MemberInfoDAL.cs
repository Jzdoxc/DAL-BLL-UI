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
    public class MemberInfoDAL
    {
        public List<MemberInfo> GetList(MemberInfo mi)
        {
            
            List<MemberInfo> list = new List<MemberInfo>();
            string sql = "select * from memberinfo  mi" +
                         " inner join membertypeinfo mti" +
                         " on mi.mtypeid =mti.mid" +
                         " where mi.misdelete=0";

           

            List<MySqlParameter> listP = new List<MySqlParameter>();
            if (!string.IsNullOrEmpty(mi.MName))
            {
                sql += " and mi.mname like @name";
                listP.Add(new MySqlParameter("@name", "%" + mi.MName + "%"));
            }
            if (!string.IsNullOrEmpty(mi.MPhone))
            {
                sql += " and mi.mphone like @phone";
                listP.Add(new MySqlParameter("@phone", "%" + mi.MPhone + "%"));
            }
           
            DataTable dt = MySqlHelper.GetList(sql, listP.ToArray());
           
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new MemberInfo()
                {
                    MId = Convert.ToInt32(row["mid"]),
                    MName = row["mname"].ToString(),
                    MPhone = row["mphone"].ToString(),
                    MTypeId = Convert.ToInt32(row["mtypeid"]),
                    MMoney = Convert.ToDecimal(row["mmoney"]),
                    MIsDelete = Convert.ToBoolean(row["misdelete"]),
                    TypeTitle=row["mtitle"].ToString()
                });
            }
            return list;
        }

        public int Insert(MemberInfo mi)
        {
            string sql = "insert into memberinfo(mname,mtypeid,mphone,mmoney,misdelete) values(@name,@typeid,@phone,@money,0)";
            MySqlParameter[] ps = new MySqlParameter[]
            {
                new MySqlParameter("@name",mi.MName),
                new MySqlParameter("@typeid",mi.MTypeId),
                new MySqlParameter("@phone",mi.MPhone),
                new MySqlParameter("@money",mi.MMoney)
            };
            return MySqlHelper.ExecuteNonQuery(sql, ps);
        }
        public int Update(MemberInfo mi)
        {
            string sql = "update  memberinfo set mname=@name,mphone=@phone,mtypeid=@typeid,mmoney=@money where mid = @id";
            MySqlParameter[] ps = new MySqlParameter[]
            {
                new MySqlParameter("@name",mi.MName),
                new MySqlParameter("@typeid",mi.MTypeId),
                new MySqlParameter("@phone",mi.MPhone),
                new MySqlParameter("@money",mi.MMoney),
                new MySqlParameter("@id",mi.MId)
            };
            return MySqlHelper.ExecuteNonQuery(sql, ps);
        }

        public int Delete(int id)
        {
            //逻辑删除，将misdelete删除标记改为1
            string sql = "update memberinfo set misdelete=1 where mid=@id";
            MySqlParameter ps = new MySqlParameter("@id", id);
            return MySqlHelper.ExecuteNonQuery(sql, ps);
        }

    }
}
