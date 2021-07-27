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
    public partial class BookBack : Form
    {
        public BookBack()
        {
            InitializeComponent();
        }

        string connString = "Data Source=HAINUXG-B7CDF23;Initial Catalog=Library;User ID=sa;Password=sa";
        SqlConnection conn; //声明连接对象
        SqlCommand comm; //声明命令对象
        string sql;
        bool flag = false;
        float pay;
        //bool Ban = true;
        string Rid;
        string BISBN;
        DateTime dt = DateTime.Now;
        bool ft = true;
        int ad;
        int KP = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
            }
            catch (Exception ett)
            {

                MessageBox.Show("点击书籍继续操作。");
            }
            
            Rid = txtReaderid.Text.Trim();
            sql = String.Format("Select count(*) from Reader where Rid = '{0}'", Rid);
            comm.CommandText = sql;
            int kkk = (int)comm.ExecuteScalar();
            conn.Close();
            if (kkk <= 0)
                MessageBox.Show("身份证号查找失败！\n   请查对", "还书失败", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                sql = String.Format("select b.ISBN as ISBN, b.BookName as 书名,a.LendTime as 借阅时间,a.BackTime as 应还时间 "
            + "from bookLendList as a,BookList as b,Reader as c where a.ISBN=b.ISBN and a.Rid=c.Rid and a.Rid='{0}' and a.isback = 0", Rid);
                try
                {
                    conn.Open();
                    conn = new SqlConnection(connString);
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataSet ds = new DataSet("MyData");
                    da.Fill(ds, "MyData");
                    if (ft == true)
                    {
                        DataColumn column = new DataColumn("选择", typeof(bool));
                        ds.Tables["MyData"].Columns.Add(column);
                        dataGridView1.DataSource = ds.Tables[0];
                        dataGridView1.Columns[0].ReadOnly = true;
                        dataGridView1.Columns[1].ReadOnly = true;
                        dataGridView1.Columns[2].ReadOnly = true;
                        //dataGridView1.Columns[3].ReadOnly = true;
                        this.dataGridView1.Columns["选择"].DisplayIndex = Convert.ToInt32(0);
                        dataGridView1.Columns[4].Width = 50;
                        ft = false;
                    }
                    sql = String.Format("Select * from Reader, ReaderCategory where Reader.Rid = '{0}' and Reader.Rcategoryid = ReaderCategory.Rcategoryid", Rid);
                    comm.CommandText = sql;
                    SqlDataReader dr;
                    dr = comm.ExecuteReader();
                    dr.Read();
                    rtbRead.Clear();
                    rtbRead.Text = "身份证号：" + dr[0].ToString() + "\n姓名：" + dr["Rname"].ToString()
                        + "\n读者类别：" + dr["Rcategoryname"].ToString()
                        + "\n已借阅数目：" + "1";
                    ad = (int)dr["Rday"];
                    dr.Close();
                    sql = String.Format("Select count(*) from BookLendList where Rid = '{0}' and BackTime < '{1}' and isBack = 0", Rid, dt);
                    comm.CommandText = sql;
                    int k = (int)comm.ExecuteScalar();
                    KP = k;
                    rtbRead.Text += k.ToString();
                    btnYes.Enabled = true;
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

        private void BookBack_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(connString); //创建Connection对象
            comm = new SqlCommand(); //创建Commmand对象
            comm.Connection = conn; //设置command使用的Connection对象
            btnYes.Enabled = false;
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            int cnt = 0;
            int select = 0;
            string ddd = "";
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                if (dataGridView1.Rows[i].Cells[4].Value.ToString() == "True")
                {
                    cnt++;
                }
            }
            if (cnt > 1)
                MessageBox.Show("只能选择一本书！", "还书失败", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (cnt == 0)
                MessageBox.Show("请选择要归还书籍！", "还书失败", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if (dataGridView1.Rows[i].Cells[4].Value.ToString() == "True")
                    {
                        select = i;
                        ddd = dataGridView1.Rows[i].Cells[3].Value.ToString();
                        BISBN = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        break;
                    }
                }

                string a = ddd.Substring(0, ddd.IndexOf("/"));
                int t = ddd.IndexOf("/");
                ddd = ddd.Remove(t, 1);
                ddd = ddd.Insert(t, "a");
                int t1 = ddd.IndexOf("a");
                t = ddd.IndexOf("/") - 1;
                string b = ddd.Substring(t1 + 1, t - t1);
                if (b.Length == 1)
                    b = "0" + b;
                t1 = ddd.IndexOf(" ") - 1;
                string c = ddd.Substring(t + 2, t1 - t - 1);
                if (c.Length == 1)
                    c = "0" + c;
                System.Globalization.DateTimeFormatInfo dtFormat = new System.Globalization.DateTimeFormatInfo();
                dtFormat.ShortDatePattern = "yyyy/MM/dd";
                DateTime dd = Convert.ToDateTime(a + "/" + b + "/" + c, dtFormat);
                conn.Open();
                sql = String.Format("Update BookLendList set BackTime = '{0}', isback = 1,  where Rid = '{1}' and ISBN = '{2}'", "2020-10-10",  Rid, BISBN);
                comm.CommandText = sql;
                try
                {
                    int kkkk = (int)comm.ExecuteNonQuery();
                    kkkk += (int)comm.ExecuteNonQuery();
                    sql = String.Format("Update BookList set lendnum = lendnum - 1 where ISBN = '{0}'", BISBN);
                    comm.CommandText = sql;
                    kkkk += (int)comm.ExecuteNonQuery();
                    if (kkkk >= 3)
                    {
                        MessageBox.Show("还书成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridView1.Rows.RemoveAt(select);
                        flag = false;
                        //Ban = true;
                    }
                    else
                    {
                        MessageBox.Show("还书失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        flag = false;
                    }
                    conn.Close();
                }
                catch (Exception err)
                {
                    MessageBox.Show("还书成功");
                    rtbRead.Text = "";
                    dataGridView1.Dispose();
                }
               
            }
        }
    }
}
