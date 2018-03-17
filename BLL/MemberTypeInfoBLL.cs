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
        private MemberTypeInfoDAL mtiDal = new MemberTypeInfoDAL();
        public List<MemberTypeInfo> GetList()
        {
            List<MemberTypeInfo> list = new List<MemberTypeInfo>();
            list = mtiDal.GetList();
            return list;
        }

        public bool Add(MemberTypeInfo mti)
        {
            return mtiDal.Insert(mti)>0;
        }

        public bool Edit(MemberTypeInfo mti)
        {
            return mtiDal.Update(mti) > 0;
        }

        public bool Remove(int id)
        {
            return mtiDal.Delete(id) > 0;
        }

     
    }
}
