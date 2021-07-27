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
    public partial class ChangeBookList : Form
    {
        public ChangeBookList()
        {
            InitializeComponent();
        }

        string connString = "Data Source=HAINUXG-B7CDF23;Initial Catalog=Library;User ID=sa;Password=sa";
        SqlConnection conn;
        SqlDataReader dr;
        class BookCategory
        {
            public int Bid;
            public string Iname;
            public BookCategory(int id, string name)
            {
                Bid = id;
                Iname = name;
            }
            public override string ToString()
            {
                return Iname;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(connString);
            string isbn = textBox1.Text.Trim();
            string sql = "select * from BookList where ISBN='" + isbn + "'";
            SqlCommand comm = new SqlCommand(sql, conn);
            bool error = true;
            try
            {
                conn.Open();
                dr = comm.ExecuteReader();
                if (!dr.Read())
                {
                    MessageBox.Show("图书信息不存在！", "数据出错！", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    error = false;
                }
                dr.Close();
                dr = comm.ExecuteReader();
                while (dr.Read())
                {
                    textBox2.Text = dr["ISBN"].ToString().Trim();
                    textBox3.Text = dr["author"].ToString().Trim();
                    textBox4.Text = dr["BookName"].ToString().Trim();
                    textBox7.Text = dr["num"].ToString().Trim();
                    totrue();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "操作数据库出错！", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
            finally
            {
                dr.Close();
                conn.Close();
            }
            if (error == true)
            {
                SqlConnection CONN = new SqlConnection(connString);
                string SQL = "select * from BookCategory";
                SqlCommand COMM = new SqlCommand(SQL, CONN);
                comboBox1.Items.Clear();
                try
                {
                    CONN.Open();
                    dr = COMM.ExecuteReader();
                    while (dr.Read())
                    {
                        int id = (int)dr[0];
                        string bCategoryname = dr["bCategoryname"].ToString().Trim();
                        comboBox1.Items.Add(new BookCategory(id, bCategoryname));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "操作数据库出错！", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
                finally
                {
                    dr.Close();
                    CONN.Close();
                }
                comboBox1.SelectedIndex = 0;
            }
        }

        private void tofalse()
        {
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox7.Enabled = false;
            button2.Enabled = false;
            comboBox1.Enabled = false;
        }

        private void totrue()
        {
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox7.Enabled = true;
            button2.Enabled = true;
            comboBox1.Enabled = true;
        }

        private void ChangeBookList_Load(object sender, EventArgs e)
        {
            textBox2.Enabled = false;
            tofalse();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string ISBN = textBox1.Text.Trim();
            string isbn = textBox2.Text.Trim();
            string name = textBox4.Text.Trim();
            string bookname = comboBox1.Text.Trim();
            string author = textBox3.Text.Trim();
            int num = 0;
            bool error = true;
            if (textBox4.Text == "")
            {
                MessageBox.Show("书名不能为空！", "数据出错！", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                error = false;
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("第一作者不能为空！", "数据出错！", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                error = false;
            }
            else if (textBox7.Text == "")
            {
                MessageBox.Show("库存数目不能为空！", "数据出错！", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                error = false;
            }
            try
            {
                num = Convert.ToInt32(textBox7.Text);
            }
            catch (Exception ex)
            {
                if (error == true)
                {
                    MessageBox.Show(ex.Message, "数据出错！", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                error = false;

            }
            if (error == true)
            {

                if (isbn != "" || name != "" || author != "")
                {
                    string information = "\nISBN:" + isbn + "\n书名：" + name + "\n第一作者：" + author
                        + "\n图书类别：" + bookname + "\n库存数目：" + num;
                    SqlConnection conn1 = new SqlConnection(connString);
                    DialogResult result = MessageBox.Show("是否确定修改图书信息：" + information,
                        "修改确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        try
                        {
                            int Bid = 0;
                            BookCategoryHelper bookcategory = comboBox1.SelectedItem as BookCategoryHelper;
                            if (bookcategory != null) Bid = bookcategory.bookCategoryID;
                            string Sql = String.Format("update BookList set ISBN='{0}',BookName='{1}',bCategoryid='{2}',"
                                + "author='{3}',publisher='{4}',lendnum='{8}'", isbn, name, Bid, author, num, 0);
                            Sql += " where ISBN='" + ISBN + "'";
                            SqlCommand comm1 = new SqlCommand(Sql, conn1);
                            conn1.Open();
                            int count = comm1.ExecuteNonQuery();
                            if (count > 0)
                                MessageBox.Show("修改图书信息成功", "修改成功", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            else
                                MessageBox.Show("修改图书信息失败", "修改失败", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "操作数据库出错！", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        }
                        finally
                        {
                            conn1.Close();
                        }
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox7.Text = "";
                        //comboBox1.SelectedIndex = 0;
                    }
                }

            }
        }
    }



}
