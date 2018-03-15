using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class MemberTypeInfo
    {
        public int MId { get; set; }
        public string MTitle { get; set; }
        public Decimal MDiscount { get; set; }
        public bool MIsDelete { get; set; }
    }
}
