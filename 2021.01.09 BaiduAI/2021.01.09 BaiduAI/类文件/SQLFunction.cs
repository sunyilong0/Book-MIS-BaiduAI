using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    class SQLFunction
    {

        /// <summary>
        /// 刷新数据表
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="SqlName"></param>
        public static void RefreshDataGridView(DataGridView dgv, string SqlName)
        {
            String CommandText = "SELECT * FROM " + SqlName;
            dgv.DataSource = DBHelper.ExecuteReTable(CommandText, SqlName);
            dgv.DataMember = SqlName.ToLower();
            DBHelper.Conn.Close();
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <param name="SqlName"></param>
        /// <param name="dgv"></param>
        public static int Insert(string str1, string str2, string SqlName)
        {
            int k = 0;
            try
            {
                string CommandText = "INSERT INTO " + SqlName + "(" + str1 + ")VALUES("
                                     + str2 + ")";
                k = DBHelper.ExecuteCommand(CommandText);
                DBHelper.Conn.Close();
                return k;
            }
            catch (SqlException err)
            {
                MessageBox.Show(err.ToString());
                return k;
            }

        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <param name="SqlName"></param>
        /// <param name="dgv"></param>
        public static void Delete(string Name, string SqlName, DataGridView dgv)
        {
            try
            {
                int row = dgv.CurrentCell.RowIndex;     //获取当前所选数据行的索引
                string ID = dgv.Rows[row].Cells[0].Value.ToString().Trim();
                String CommandText = "DELETE FROM " + SqlName + "WHERE" + Name + " = " + "'" + ID + "'";
                DBHelper.ExecuteCommand(CommandText);
                RefreshDataGridView(dgv, SqlName);
                MessageBox.Show("删除成功");
            }
            catch (SqlException err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        /// <summary>
        /// 查找数据
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="str2"></param>
        /// <param name="SqlName"></param>
        /// <param name="dgv"></param>
        public static void Search(string ID, string str2, string SqlName, DataGridView dgv)
        {
            try
            {
                String CommandText = "SELECT * FROM " + SqlName + "WHERE " + ID + " = " + "'" + str2 + "'";
                int k = DBHelper.ExecuteSelect(CommandText);
                if (k == 1)
                {
                    DBHelper.ExecuteReTable(CommandText, SqlName);
                    RefreshDataGridView(dgv, SqlName);
                    MessageBox.Show("查找成功");
                }
                else
                {
                    MessageBox.Show("未找到指定结果");
                }
            }
            catch (SqlException err)
            {
                MessageBox.Show(err.ToString());
            }
            finally
            {
                DBHelper.Conn.Close();
            }
        }

        public static void SeeAllInfo(string SqlName, DataGridView dgv)
        {
            try
            {
                String CommandText = "SELECT * FROM " + SqlName;
                DBHelper.ExecuteReTable(CommandText, SqlName);
                RefreshDataGridView(dgv, SqlName);
                DBHelper.Conn.Close();
            }
            catch (SqlException err)
            {
                MessageBox.Show(err.ToString());
            }
        }
    }
}
