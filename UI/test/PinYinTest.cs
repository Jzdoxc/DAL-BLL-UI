using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.International.Converters.PinYinConverter;
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
            string s = textBox1.Text;
            foreach (char c in s)
            {
                ChineseChar cc = new ChineseChar(c);
                foreach(var c1 in cc.Pinyins)
                {
                    label1.Text += c1 + " ";
                }
            }
        }
    }
}
