using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.International.Converters.PinYinConverter;
namespace Common
{
   public  class PinYinHelper
    {
        public static string GetPinYin(string txt)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in txt)
            {
                if (ChineseChar.IsValidChar(c))
                {
                    ChineseChar cc = new ChineseChar(c);
                    sb.Append(cc.Pinyins[0][0]);
                }
                else
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }
}
