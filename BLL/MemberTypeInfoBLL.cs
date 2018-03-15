using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using MODEL;
namespace BLL
{
    public class MemberTypeInfoBLL
    {
        private MemberTypeInfoDAL miDal = new MemberTypeInfoDAL();
        public List<MemberTypeInfo> GetList()
        {
            List<MemberTypeInfo> list = new List<MemberTypeInfo>();
            list = miDal.GetList();
            return list;
        }
    }
}
