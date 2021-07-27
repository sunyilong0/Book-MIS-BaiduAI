using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        string connString = @"Data Source=HAINUXG-B7CDF23;Initial Catalog=Library;User ID=sa;Password=sa";
        SqlConnection conn;
        SqlCommand comm;
        SqlDataReader dr;

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "select*from Manager where mIdentity=0";
            try
            {
                string Password = "";
                conn = new SqlConnection(connString);
                conn.Open();
                comm = new SqlCommand(sql, conn);
                dr = comm.ExecuteReader();
                while (dr.Read())
                {
                    string id = dr["managerid"].ToString().Trim();
                    if (id == textBox1.Text.Trim())
                    {
                        Password = dr["managerPassword"].ToString().Trim();
                        break;
                    }

                }
                dr.Close();//关闭DataReader
                if (Password != textBox2.Text.Trim())
                {
                    MessageBox.Show("用户名或密码错误！", "请重新填写密码！", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                }
                else if (textBox3.Text.Trim() != textBox4.Text.Trim())
                {
                    MessageBox.Show("两次输入的新密码不同！", "请重新填写新密码！", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                }
                else
                {
                    sql = String.Format("Update Manager set managerPassword='{0}' where managerid='{1}'", textBox3.Text.Trim(), textBox1.Text.Trim());
                }
                SqlCommand comm0 = new SqlCommand(sql, conn);
                int count = comm0.ExecuteNonQuery();
                if (count > 0)
                {
                    MessageBox.Show("修改密码成功！", "修改成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = ""; textBox4.Text = "";

                }
                //else
                //  MessageBox.Show("修改密码失败！", "修改失败", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "操作数据库出错！", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
