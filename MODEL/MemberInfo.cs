using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
   public  class MemberInfo
    {
        public int MId { get; set; }
        public string MName { get; set; }
        public string MPhone { get; set; }
        public Decimal MMoney { get; set; }
        public Boolean MIsDelete { get; set; }
        public int MTypeId { get; set; }
        //用于做连接查询存储结果
        public string TypeTitle { get; set; }
    }
}
