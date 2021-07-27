using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Addwork : Form
    {
        public Addwork()
        {
            InitializeComponent();
        }

        MangerHelper mh;

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == string.Empty || textBox2.Text.Trim() == string.Empty || textBox3.Text.Trim() == string.Empty)
            {
                MessageBox.Show("信息不完整", "信息不完整", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                string username = textBox1.Text.Trim();
                string password1 = textBox2.Text.Trim();
                string password2 = textBox3.Text.Trim();

                if (password1 != password2)
                {
                    MessageBox.Show("两次密码不一致", "添加失败", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox3.Clear();
                }
                else
                {
                    try
                    {
                        mh = new MangerHelper(username, password1);
                        if (mh.InsertWorker(textBox1) > 0)
                            MessageBox.Show("添加成功", "添加成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("添加成功", "添加成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message, "操作数据库出错", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                }
            }
        }
    }
}
