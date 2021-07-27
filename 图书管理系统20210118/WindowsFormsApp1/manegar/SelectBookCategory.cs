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

namespace WindowsFormsApp1.work
{
    public partial class SelectBookCategory : Form
    {
        public SelectBookCategory()
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
                case "编号":
                    condition = String.Format("bCategoryid like '%{0}%'", valuel); break;
                case "名称":
                    condition = String.Format("bCategoryname like '%{0}%'", valuel); break;
            }
            string sql = "select bCategoryid as 图书类别编号,bCategoryname as 图书类别名称"
                    + " from BookCategory where " + condition;
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            if (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count == 0)
                MessageBox.Show("没有符合条件的记录", "请选择合适的条件！", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string key = comboBox1.SelectedItem.ToString();
            textBox1.Text = "";
        }

        private void SelectBookCategory_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(connString);
            comboBox1.Items.Add("编号");
            comboBox1.Items.Add("名称");
            comboBox1.SelectedIndex = 0;
        }


    }
}
