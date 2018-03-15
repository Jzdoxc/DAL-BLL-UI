using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
namespace UI
{
    public partial class MemberTypeInfoList : Form
    {
        public MemberTypeInfoList()
        {
            InitializeComponent();
        }

        MemberTypeInfoBLL miBLL = new MemberTypeInfoBLL();

        private void MemberTypeInfoList_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        private void LoadList()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = miBLL.GetList();
        }
    }
}
