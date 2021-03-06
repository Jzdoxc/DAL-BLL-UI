﻿using System;
using System.Windows.Forms;
using BLL;
using MODEL;

namespace UI
{
    public partial class MemberTypeInfoList : Form
    {
        public MemberTypeInfoList()
        {
            InitializeComponent();
        }

        private void MemberTypeInfoList_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        private void LoadList()
        {
            var miBll = new MemberTypeInfoBLL();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = miBll.GetList();
        }

        private void btn_Insert_Click(object sender, EventArgs e)
        {
            var mtiBll = new MemberTypeInfoBLL();


            if (btn_Save.Text.Equals("添加"))
            {
                var mti = new MemberTypeInfo
                {
                    MTitle = textBox2.Text,
                    MDiscount = Convert.ToDecimal(textBox3.Text)
                };
                //添加逻辑
                if (mtiBll.Add(mti))
                {
                    LoadList();
                    btn_Cancel_Click(null, null);
                    UpdateTypeEvent();
                    MessageBox.Show("添加成功");
                }
                else
                {
                    MessageBox.Show("添加失败");
                }
            }
            else if (btn_Save.Text.Equals("修改"))
            {
                MemberTypeInfo mti = new MemberTypeInfo
                {
                    MId = Convert.ToInt32(textBox1.Text),
                    MTitle = textBox2.Text,
                    MDiscount = Convert.ToDecimal(textBox3.Text)
                };
                if (mtiBll.Edit(mti))
                {
                    LoadList();
                    btn_Cancel_Click(null, null);
                    MessageBox.Show("修改成功");
                }
                else
                {
                    MessageBox.Show("修改失败");
                }
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            btn_Save.Text = "修改";
            var row = dataGridView1.SelectedRows;
            textBox1.Text = row[0].Cells[0].Value.ToString();
            textBox2.Text = row[0].Cells[1].Value.ToString();
            textBox3.Text = row[0].Cells[2].Value.ToString();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            textBox1.Text = "添加时无编号";
            textBox2.Text = "";
            textBox3.Text = "";
            btn_Save.Text = "添加";
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            MemberTypeInfoBLL mtiBll = new MemberTypeInfoBLL();
            
            //获取选择的行，找到对应的编号
            var row = dataGridView1.SelectedRows;
            if (row.Count>0)
            {
                DialogResult result = MessageBox.Show("确定要删除吗", "提示", MessageBoxButtons.OKCancel);
                if (result==DialogResult.OK)
                {
                    int id = int.Parse(row[0].Cells[0].Value.ToString());
                    if (mtiBll.Remove(id))
                    {
                        btn_Cancel_Click(null, null);
                        LoadList();
                        UpdateTypeEvent();
                    }
                    else
                    {
                        MessageBox.Show("删除失败，请稍后再试");
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择要删除的数据");
            }
        }

        public event Action UpdateTypeEvent;
    }
}