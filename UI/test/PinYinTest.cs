using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
namespace UI.test
{
    public partial class PinYinTest : Form
    {
        public PinYinTest()
        {
            InitializeComponent();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label1.Text = PinYinHelper.GetPinYin(textBox1.Text);
            ////清空文本字符串
            //label1.Text = "";
            ////获取用户输入的字符串
            //string s = textBox1.Text;
            ////遍历字符串获取拼音
            //foreach (char c in s)
            //{
            //    //判断指定的字符是否是汉字
            //    if (ChineseChar.IsValidChar(c))
            //    {
            //        //构造字符对象
            //        ChineseChar cc = new ChineseChar(c);
            //        //获取拼音首字母，返回集合，因为存在多音字
            //        label1.Text += cc.Pinyins[0][0];
            //    }

            //    //foreach(var c1 in cc.Pinyins)
            //    //{
            //    //    label1.Text += c1 + " ";
            //    //}
            //    else
            //    {
            //        label1.Text += c;
            //    }
            //}
        }
    }
}
