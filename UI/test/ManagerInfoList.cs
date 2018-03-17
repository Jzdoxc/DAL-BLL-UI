using System;
using System.Windows.Forms;
using BLL;
using MODEL;

namespace UI.test
{
    public partial class ManagerInfoList : Form
    {
        private readonly ManagerInfoBLL miBll = new ManagerInfoBLL();

        public ManagerInfoList()
        {
            InitializeComponent();
        }

        private void ManagerInfoList_Load(object sender, EventArgs e)
        {
            #region 旧版

            /* 
             //1.创建连接对象
             using (MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString))
             {
                 string sql = "select * from managerinfo";
                 MySqlCommand cmd = new MySqlCommand(sql, con);
                 //2.打开
                 con.Open();
                 //3.执行命令
                 MySqlDataReader reader = cmd.ExecuteReader();

                 List<ManagerInfo> list = new List<ManagerInfo>();
                 //4.读取结果
                 while (reader.Read())
                 {
                     list.Add(new ManagerInfo()
                     {
                         MId = Convert.ToInt32(reader["MId"]),
                         MName = reader["mname"].ToString(),
                         MPwd = reader["mpwd"].ToString(),
                         MType = Convert.ToInt32(reader["mtype"])
                     }//对象的初始化器
                     );
                 }
                 //5.使用
                 dataGridView1.DataSource = list;

               */

            #endregion

            Loadlist();
        }

        private void Loadlist()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = miBll.GetList();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2)
                switch (e.Value.ToString())
                {
                    case "1":
                        e.Value = "经理";
                        break;
                    case "0":
                        e.Value = "店员";
                        break;
                    default:
                        break;
                }
        }

        private void btn_Insert_Click(object sender, EventArgs e)
        {
            var mi = new ManagerInfo
            {
                MName = textBox2.Text,
                MPwd = textBox3.Text,
                MType = rb1.Checked ? 1 : 0
            };

            if (btn_Insert.Text.Equals("添加"))
            {
                if (miBll.Add(mi))
                    Loadlist();
                else
                    MessageBox.Show("添加失败");
            }
            else if (btn_Insert.Text.Equals("修改"))
            {
                mi.MId = Convert.ToInt32(textBox1.Text);
                if (miBll.Update(mi))
                {
                    Loadlist();
                    btn_Insert.Text = "添加";
                }
                else
                {
                    MessageBox.Show("更新失败");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //获取选中的行
            var rows = dataGridView1.SelectedRows;
            if (rows.Count > 0)
            {
                var result = MessageBox.Show("确定要删除吗", "提示", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    var id = Convert.ToInt32(rows[0].Cells[0].Value);
                    if (miBll.Remove(id))
                        Loadlist();
                    else
                        MessageBox.Show("删除失败，请稍后重试");
                }
            }
            else
            {
                MessageBox.Show("未选中要删除的行");
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridView1.Rows[e.RowIndex];
            textBox1.Text = row.Cells[0].Value.ToString();
            textBox3.Text = "******";
            textBox2.Text = row.Cells[1].Value.ToString();
            if (row.Cells[2].Value.ToString() == "1")
                rb1.Checked = true;
            else
                rb2.Checked = true;
            btn_Insert.Text = "修改";
        }

    }
}