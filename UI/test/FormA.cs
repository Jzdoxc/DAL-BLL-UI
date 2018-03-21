using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.test
{
    public partial class FormA : Form
    {
        public FormA()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormB formB = new FormB();
            formB.SetTextEvent += SetText;//绑定事件处理函数
            formB.Show();
        }

        private void SetText(string txt1)
        {
            //用于事件处理的方法，将传递的值设置到文本框中
            textBox1.Text = txt1;
        }
    }
}
