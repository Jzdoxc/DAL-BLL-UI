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
using MODEL;

namespace UI
{
    public partial class MemberInfoList : Form
    {
        //将构造方法私有
        private MemberInfoList()
        {
            InitializeComponent();
        }
        //通过指定的方法创建窗体对象
        private static MemberInfoList mil;
        public static MemberInfoList Create()
        {
            //判断是否不存在
            if(mil==null)
            {
                mil = new MemberInfoList();
            }
            return mil;
        }
        private MemberInfoBLL miBll = new MemberInfoBLL();
        private void MemberInfoList_Load(object sender, EventArgs e)
        {
            
            LoadList();
            LoadComboxItems();
        }

        private void LoadList()
        {
            MemberInfo mi = new MemberInfo();
            mi.MName = txt_SearchName.Text;
            mi.MPhone = txt_SearchPhone.Text;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = miBll.GetList(mi);
        }

        private void LoadComboxItems()
        {
            MemberTypeInfoBLL mtiBll = new MemberTypeInfoBLL();
            List<MemberTypeInfo> list = mtiBll.GetList();
            comboBox1.DisplayMember = "MTitle";
            comboBox1.ValueMember = "MId";
            comboBox1.DataSource = list;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MemberInfo mi = new MemberInfo
            {
                MName = txt_AddName.Text,
                MPhone = txt_Phone.Text,
                MMoney = Convert.ToDecimal(txt_Money.Text),
                MTypeId=Convert.ToInt32(comboBox1.SelectedValue)
            };
            if (btn_Save.Text.Equals("添加"))
            {
                if (miBll.Insert(mi))
                {
                    LoadList();
                    btn_Cancel_Click(null, null);
                    MessageBox.Show("添加成功");
                }
                else
                {
                    MessageBox.Show("添加失败");
                }
            }
            else if(btn_Save.Text.Equals("修改"))
            {
                mi.MId = Convert.ToInt32(txt_Id.Text);
                if (miBll.Update(mi))
                {
                    btn_Cancel_Click(null, null);
                    MessageBox.Show("更新成功");
                    LoadList();
                }
                else
                {
                    MessageBox.Show("更新失败");
                }
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            txt_Id.Text = "添加时无编号";
            txt_AddName.Text = "";
            txt_Money.Text = "";
            txt_Phone.Text = "";
            btn_Save.Text = "添加";
            comboBox1.SelectedIndex = 0;

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridView1.Rows[e.RowIndex];
            txt_Id.Text = row.Cells[0].Value.ToString();
            txt_AddName.Text = row.Cells[1].Value.ToString();
            comboBox1.Text = row.Cells[2].Value.ToString();
            txt_Phone.Text = row.Cells[3].Value.ToString();
            txt_Money.Text = row.Cells[4].Value.ToString();
            btn_Save.Text = "修改";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var rows = dataGridView1.SelectedRows;
            if (rows.Count>0)
            {
                DialogResult result = MessageBox.Show("确定要删除吗", "提示", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    int id = int.Parse(rows[0].Cells[0].Value.ToString());
                    if (miBll.Delete(id))
                    {
                        btn_Cancel_Click(null, null);
                        MessageBox.Show("删除成功");
                        LoadList();
                    }
                    else
                    {
                        MessageBox.Show("删除失败");
                    }
                }
            }
            else
            {
                MessageBox.Show("请选中需要删除的行");
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txt_SearchName.Text = "";
            txt_SearchPhone.Text = "";
            LoadList();


        }

        private void txt_SearchName_Leave(object sender, EventArgs e)
        {
            LoadList();
        }

        private void txt_SearchPhone_Leave(object sender, EventArgs e)
        {
            LoadList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MemberTypeInfoList mtilist = new MemberTypeInfoList();
            mtilist.UpdateTypeEvent += UpdateType;
            mtilist.Show();

        }

        private void MemberInfoList_FormClosing(object sender, FormClosingEventArgs e)
        {
            mil = null;
        }
        
        private void UpdateType()
        {
            LoadComboxItems();
            LoadList();

        }

    }
}
