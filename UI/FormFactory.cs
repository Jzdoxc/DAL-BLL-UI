using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.test;

namespace UI
{
    class FormFactory
    {
        //定义静态变量，用于存储单例对象
        private static ManagerInfoList managerInfoList;
        //创建对象的方法
        public static ManagerInfoList CreateMIL()
        {
            //判断对象是否存在或者是否已经被释放
            if (managerInfoList == null || managerInfoList.IsDisposed)
            {
                //新建对象
                managerInfoList = new ManagerInfoList();
            }
            //返回对象
            return managerInfoList;
        }
    }
}
