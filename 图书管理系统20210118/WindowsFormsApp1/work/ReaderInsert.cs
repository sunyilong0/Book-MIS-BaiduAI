using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;


namespace WindowsFormsApp1
{
    public partial class ReaderInsert : Form
    {

        ReaderHelper rh;
        public ReaderInsert()
        {
            InitializeComponent();
        }


        /// <summary>
        ///检查身份证输入是否正确
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private bool check(string s)
        {
            if (s.Length != 18)
                return false;
            int flag = 1;
            for (int i = 0; i < 17; i++)
            {
                if (!(s[i] >= '0' && s[i] <= '9'))
                {
                    flag = 0;
                    break;
                }
            }
            if (flag == 0)
                return false;
            if ((s[17] >= '0' && s[17] <= '9') || s[17] == 'X')
                return true;
            return false;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Regex reg = new Regex("^[0-9]*$");
            if (txtID.Text.Trim() == string.Empty || txtName.Text.Trim() == string.Empty || txtPhoneNumber.Text.Trim() == string.Empty)
            {
                MessageBox.Show("信息不完整", "信息不完整", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (!check(txtID.Text))
            {
                MessageBox.Show("身份证号格式错误", "信息格式错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if(!reg.IsMatch(txtPhoneNumber.Text.Trim()))
            {
                MessageBox.Show("电话号必须为数字", "信息格式错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                
            }
            else
            {
                try
                {
                    string ID=txtID.Text;
                    string Phone = txtPhoneNumber.Text;
                    string readerName = txtName.Text;

                    rh = new ReaderHelper(ID, readerName, Phone,1);
                    rh.Insert();

                }
                catch (SqlException err)
                {
                    MessageBox.Show(err.ToString());
                }

                
            }


        }
    }
}
