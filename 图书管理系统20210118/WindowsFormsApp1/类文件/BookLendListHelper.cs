using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class BookLendListHelper
    {
        static string SqlName = "BookList";

        public string ISBN { get; set; }
        public string BookName { get; set; }
        public int bCategoryid { get; set; }
        public string author { get; set; }
        public int num { get; set; }
        public int lendnum { get; set; }
        public float price { get; set; }       

        public BookLendListHelper(string ISBN, string BookName, int bCategoryid, string author, int num, int lendnum, float price)
        {
            this.ISBN = ISBN;
            this.BookName = BookName;
            this.bCategoryid = bCategoryid;
            this.author = author;
            this.num = num;
            this.lendnum = lendnum;
            this.price = price;
        }

        public void Insert()
        {
            string str1 = " ISBN," + "BookName," + "bCategoryid," + "author," + "num," + "lendnum," + "price";
            string str2 = " '" + ISBN + "'," + "'" + BookName + "'," + "'" + bCategoryid + "'," + "'" + author + "'," + num + "," + lendnum + "," + price;
            SQLFunction.Insert(str1, str2, SqlName);
        }

        /// <summary>
        /// Delete book Infomation by ISBN
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="ISBN"></param>
        public static void Delete(DataGridView dgv, int ISBN)
        {
            try
            {
                String CommandText = "Delete FROM BookList Where ISBN = " + "'" + ISBN + "'";
                DBHelper.ExecuteCommand(CommandText);
                SQLFunction.RefreshDataGridView(dgv, SqlName);
                MessageBox.Show("删除成功");
                DBHelper.Conn.Close();
            }
            catch (SqlException err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        /// <summary>
        /// Check all books' infomation
        /// </summary>
        /// <param name="dgv"></param>
        public static void SeeAllInfo(DataGridView dgv)
        {
            SQLFunction.SeeAllInfo(SqlName, dgv);
        }

        public static void Update()
        {

        }

        /// <summary>
        /// 根据ISBN码查找书籍
        /// </summary>
        /// <param name="ISBN"></param>
        /// <returns></returns>
        public static int SearchISBN(int ISBN)
        {
            string CommandText = String.Format("Select count(*) from BookList where ISBN = '{0}' ", ISBN);
            return DBHelper.ExecuteSelect(CommandText);
        }
    }
}
