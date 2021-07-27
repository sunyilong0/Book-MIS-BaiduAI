using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    class ReaderHelper : SQLFunction
    {

        static string Sqlname = "Reader";

        public string ReaderID { get; set; }
        public string ReaderName { get; set; }
        public string ReaderPhoneNumber { get; set; }

        public ReaderHelper(string ID, string Name, string number)
        {
            ReaderID = ID;
            ReaderName = Name;
            ReaderPhoneNumber = number;
        }

        public static void Update(string ID, DataGridView dgv)
        {
            //String Pwd = "'" + managerPwd.Trim() + "',";
            //String CommandText = "UPDATE Manager SET managerPassword=" + Pwd + "WHERE ID=" + ID;
            //DBHelper.ExecuteCommand(CommandText);
            //SQLFunction.RefreshDataGridView(dgv, sqlName);
        }

        public void Insert()
        {
            string str1 = " Rid," + "Rname," + "Phone";
            string str2 = "'" + ReaderID + "'," + "'" + ReaderName + "'," + "'" + ReaderPhoneNumber + "'";
            String CommandText = "SELECT COUNT(Rid) FROM Reader WHERE Rid=" + ReaderID;
            if (int.Parse((DBHelper.ExecuteReArrList(CommandText))[0].ToString()) > 0)
            {
                MessageBox.Show("读者已存在");
            }
            else
            {
                int k = SQLFunction.Insert(str1, str2, "Reader");
                if (k>0)
                {
                    MessageBox.Show("读者信息添加成功");
                }
                else
                {
                    MessageBox.Show("读者信息添加失败");
                }
            }
        }

        public static void SeeAllInfo(DataGridView dgv)
        {
            SQLFunction.SeeAllInfo(Sqlname, dgv);
        }

        public static void Delete(DataGridView dgv, string ID)
        {
            try
            {
                String CommandText = "Delete FROM Reader Where Rid = " + "'" + ID + "'";
                DBHelper.ExecuteCommand(CommandText);
                SQLFunction.RefreshDataGridView(dgv, Sqlname);
                MessageBox.Show("删除成功");
                DBHelper.Conn.Close();
            }
            catch (SqlException err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        public static void Search(string ID, DataGridView dgv)
        {
            try
            {
                String CommandText = "SELECT COUNT(*) FROM Reader WHERE Rid = '{0}'" + ID;
                DBHelper.ExecuteCommand(CommandText);
                dgv.DataSource = DBHelper.ExecuteReTable(CommandText, Sqlname);
                DBHelper.Conn.Close();
            }
            catch (SqlException err)
            {
                MessageBox.Show(err.ToString());
            }


        }
    }
}
