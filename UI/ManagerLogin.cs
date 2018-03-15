using BLL;
using MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class ManagerLogin : Form
    {
        public ManagerLogin()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            ManagerInfo mi = new ManagerInfo()
            {
                MName=txtName.Text,
                MPwd=txtPwd.Text
            };
            ManagerInfoBLL Bll = new ManagerInfoBLL();
            if (Bll.Login(mi))
            {
                new MainForm().Show();
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("用户名或者密码错误");
            }

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
