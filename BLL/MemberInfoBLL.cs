using DAL;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MemberInfoBLL
    {
        private MemberInfoDAL miDal = new MemberInfoDAL();

        public List<MemberInfo> GetList()
        {
            return miDal.GetList(null);
        }

        public List<MemberInfo> GetList(MemberInfo mi)
        {
            return miDal.GetList(mi);
        }
        public bool Insert(MemberInfo mi)
        {
            return miDal.Insert(mi)>0;
        }

        public bool Update(MemberInfo mi)
        {
            return miDal.Update(mi)>0;
        }

        public bool Delete(int id)
        {
            return miDal.Delete(id)>0;
        }
    }
}
