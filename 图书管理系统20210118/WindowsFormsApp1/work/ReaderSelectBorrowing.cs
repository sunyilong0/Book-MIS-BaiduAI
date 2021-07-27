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
    public partial class ReaderSelectBorrowing : Form
    {
        public ReaderSelectBorrowing()
        {
            InitializeComponent();
        }

        private void 借阅查询_Load(object sender, EventArgs e)
        {

        }
        string connString = @"Data Source=HAINUXG-B7CDF23;Initial Catalog=Library;User ID=sa;Password=sa";
        SqlConnection conn;
        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "select c.Rname as 姓名,b.BookName as 书名,a.LendTime as 借书时间,a.BackTime as 还书时间,a.money as 超期扣款,a.isback as 是否归还 "
            + "from bookLendList as a,BookList as b,Reader as c where a.ISBN=b.ISBN and a.Rid=c.Rid and a.Rid='" + textBox1.Text.Trim() + "'";
            try
            {
                conn = new SqlConnection(connString);
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                if (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count == 0)
                    MessageBox.Show("没有相关记录", "请输入准确数据！", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "操作数据库出错！", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
