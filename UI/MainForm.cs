using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.test;

namespace UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void menuManager_Click(object sender, EventArgs e)
        {
            ManagerInfoList miList = FormFactory.CreateMIL();//单例模式(通过工厂类）
            miList.Show();//显示窗体
            miList.Focus();//获取焦点
        }

        private void menuMember_Click(object sender, EventArgs e)
        {
            MemberInfoList miList = MemberInfoList.Create();//单例模式(隐藏现有构造方法，通过静态方法构造类)
            miList.Show();//显示窗体
            miList.Focus();//获取焦点
        }
    }
}
