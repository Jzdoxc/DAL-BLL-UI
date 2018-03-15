using DAL;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class ManagerInfoBLL
    {
        ManageInfoDAL miDal = new ManageInfoDAL();
        public List<ManagerInfo> GetList()
        {
            return miDal.GetList(null);
        }
        public bool Login(ManagerInfo mi)
        {
            var list = miDal.GetList(mi);
            if (list.Count>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Add(ManagerInfo mi)
        {
            return miDal.Insert(mi)>0;
        }
        public bool Remove(int id)
        {
            return miDal.DeleteById(id)>0;
        }
        public bool Update(ManagerInfo mi)
        {
            return miDal.Update(mi) > 0;
        }
    }
}
