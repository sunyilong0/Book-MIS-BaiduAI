using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class MangerHelper : SQLFunction
    {

        string sqlName = "Manager";
        public string managerID { get; set; }
        public string managerPwd { get; set; }

        public MangerHelper(string mID, string mPwd)
        {
            managerID = mID;
            managerPwd = mPwd;
        }

        /// <summary>
        /// 管理员修改个人密码
        /// </summary>
        /// <param name="ID"></param>
        public void Update(string ID, DataGridView dgv)
        {
            String Pwd = "'" + managerPwd.Trim() + "',";
            String CommandText = "UPDATE Manager SET managerPassword=" + Pwd + " WHERE ID= " + ID;
            DBHelper.ExecuteCommand(CommandText);
            SQLFunction.RefreshDataGridView(dgv, sqlName);
        }

        public int InsertWorker(TextBox textBox1)
        {
            string str1 = " managerid," + "managerPassword," + "mIdentity" ;
            string str2 = "'" + managerID + "'," + "'" + managerPwd + "'," + 0 ;
            string sql = String.Format("Select count(*) from Manager where managerid = '{0}' and mIdentity = 0", managerID);
            int k = DBHelper.ExecuteCommand(sql);
            if (k > 0)
            {
                textBox1.Clear();
                MessageBox.Show("该用户已是工作人员", "添加失败", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                return  SQLFunction.Insert(str1, str2, sqlName);
            }
            return 0;
        }
    }
}
