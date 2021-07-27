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
    public delegate void ChildClose();
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userId = txtID.Text;
            string userPwd = txtPwd.Text;
            bool midentity = true;

            if (rbManger.Checked)
                midentity = true;
            else if (rbWorker.Checked)
                midentity = false;

            string CommandText = String.Format("select count(*) from [Manager] where managerid='{0}' and managerPassword='{1}' and mIdentity='{2}'", userId, userPwd, midentity);
            int returnExecuteSelect = DBHelper.ExecuteSelect(CommandText);

            try
            {
                if (returnExecuteSelect == 1)
                {
                    MessageBox.Show("欢迎使用", "登陆成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (midentity)
                    {
                        //ManagerManu mm = new ManagerManu();
                        //mm.Show();
                        //txtID.Clear();
                        //txtPwd.Clear();
                        //this.Hide();
                    }
                    else
                    {
                        //WorkerMenu wm = new WorkerMenu();
                        //wm.Show();
                        //txtID.Clear();
                        //txtPwd.Clear();
                        //this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("账号或密码输入错误");
                }
            }
            catch (SqlException err)
            {
                MessageBox.Show(err.ToString());
            }

        }

        private void Login_Load(object sender, EventArgs e)
        {
            rbWorker.Checked = true;
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnshuoming_Click(object sender, EventArgs e)
        {
            MessageBox.Show("这是一个说明文档");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
