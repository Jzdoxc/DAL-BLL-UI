using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public  static class MD5Helper
    {
        public static string GetMd5(string _text)
        {
            //创建MD5对象
            MD5 md5 = MD5.Create();
            //将字符串转为字节数组
            byte[] bs = Encoding.UTF8.GetBytes(_text);
            //加密操作
           byte[] newbs = md5.ComputeHash(bs);
            //将字节数组转换为字符串
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < newbs.Length; i++)
            {
                //0-255=>00-ff 用十六进制来表示
                sb.Append(newbs[i].ToString("x2").ToLower());
            }
            return sb.ToString();
        }
    }
}
