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

namespace WindowsFormsApp1.manegar
{
    public partial class SelectBookList : Form
    {
        public SelectBookList()
        {
            InitializeComponent();
        }

        string connString = @"Data Source=HAINUXG-B7CDF23;Initial Catalog=Library;User ID=sa;Password=sa";
        SqlConnection conn;

        private void button1_Click(object sender, EventArgs e)
        {
            string key = comboBox1.SelectedItem.ToString();
            string valuel = textBox1.Text.Trim();
            string condition = "";
            switch (key)
            {
                case "ISBN号":
                    condition = String.Format(" and ISBN = '{0}'", valuel); break;
                case "书名":
                    condition = String.Format(" and BookName like '%{0}%'", valuel); break;
                case "图书类别编号":
                    condition = String.Format(" and a.bCategoryid = {0}", valuel); break;
                case "作者":
                    condition = String.Format(" and author like '%{0}%'", valuel); break;
                case "库存数目":
                    condition = String.Format(" and num  = {0}", valuel); break;
                case "借出数目":
                    condition = String.Format(" and lendnum = {0}", valuel); break;
            }
            string sql = "select a.ISBN as ISBN, a.BookName as 书名,b.bCategoryname as 图书类别名称, a.author as 第一作者, "
                    + " a.num as 库存数目, a.lendnum as 借出数目 "
                    + "from BookList as a, BookCategory as b where b.bCategoryid = a.bCategoryid " + condition;
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            if (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count == 0)
                MessageBox.Show("没有符合条件的记录", "请选择合适的条件！", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void SelectBookList_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(connString);
            comboBox1.Items.Add("ISBN号");
            comboBox1.Items.Add("书名");
            comboBox1.Items.Add("图书类别编号");
            comboBox1.Items.Add("作者");
            comboBox1.Items.Add("库存数目");
            comboBox1.Items.Add("借出数目");
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string key = comboBox1.SelectedItem.ToString();
            textBox1.Text = "";
        }
    }
}
