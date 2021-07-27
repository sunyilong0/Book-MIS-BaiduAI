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
    public partial class AddBookList : Form
    {
        BookLendListHelper blh;
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
        public AddBookList()
        {
            InitializeComponent();
        }
        private void checkk()
        {
            if (txtISBN.Text.Trim() != "")
            {
                string ISBN = txtISBN.Text.ToString().Trim();
                int flag = 1;
                if ((ISBN[0] >= '0' && ISBN[0] <= '9') && (ISBN[ISBN.Length - 1] >= '0' && ISBN[ISBN.Length - 1] <= '9'))
                {
                    for (int i = 1; i < ISBN.Length; i++)
                    {
                        if (!((ISBN[i] >= '0' && ISBN[i] <= '9') || ISBN[i] == '-') || (ISBN[i] == ISBN[i - 1] && ISBN[i] == '-'))
                        {
                            flag = 0;
                            break;
                        }
                    }
                }
                else
                    flag = 0;
                if (flag == 0)
                    MessageBox.Show("ISBN号格式错误", "添加失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    if (BookLendListHelper.SearchISBN(Convert.ToInt32(txtISBN.Text)) > 0)
                        MessageBox.Show("该ISBN号已存在，若新添该图书，请修改该图书库存数目", "添加失败", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            string isbn = txtISBN.Text;
            string bookname = txtBookName.Text;
            string author = txtWriter.Text;
            string bCategory = comboBox1.Text;
            int num = 0;
            float price = 0;
            bool flag = false;
            bool error = true;
            if (txtISBN.Text == "")
            {
                MessageBox.Show("ISBN号不能为空！", "数据出错！", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                error = false;
            }
            else if (txtBookName.Text == "")
            {
                MessageBox.Show("书名不能为空！", "数据出错！", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                error = false;
            }
            else if (txtWriter.Text == "")
            {
                MessageBox.Show("第一作者不能为空！", "数据出错！", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                error = false;
            }
            else if (txtNum.Text == "")
            {
                MessageBox.Show("库存数目不能为空！", "数据出错！", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                error = false;
            }
            else if (txtPrice.Text == "")
            {
                MessageBox.Show("单价不能为空！", "数据出错！", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                error = false;
            }
            try
            {
                num = Convert.ToInt32(txtNum.Text.Trim());
                price = float.Parse(txtPrice.Text.Trim());
                flag = true;
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

            if (num <= 0 && flag == true)
            {
                MessageBox.Show("库存数必须为正整数！", "数据出错！", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                error = false;
            }
            if (price <= 0 && flag == true)
            {
                MessageBox.Show("单价必须为正数！", "数据出错！", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                error = false;
            }
            if (error == true)
            {
                if (isbn != "" || bookname != "" || author != "")
                {
                    string information = "\nISBN:" + isbn + "\n书名：" + bookname + "\n第一作者：" + author
                        + "\n图书类别：" + bCategory + "\n库存数目：" + num + "\n价格：" + price;

                    DialogResult result = MessageBox.Show("是否确定添加图书信息：" + information,
                    "添加确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        try
                        {
                            int bCategoryID = 0;
                            blh = new BookLendListHelper(isbn, bookname, bCategoryID, author, num, 0, price);
                            if (blh != null) bCategoryID = blh.bCategoryid;
                            blh.Insert();
                            MessageBox.Show("添加图书信息成功", "添加成功", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "操作数据库出错！", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        }
                        txtBookName.Text = "";
                        txtISBN.Text = "";
                        txtNum.Text = "";
                        txtPrice.Text = "";
                        txtWriter.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("输入信息不能为空！", "数据出错！", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }

        }
        SqlDataReader dr;
        private void AddBookList_Load(object sender, EventArgs e)
        {
            SqlConnection conn;
            SqlCommand comm;

            string connString = "Data Source=HAINUXG-B7CDF23;Initial Catalog=Library;User ID=sa;Password=sa";
            conn = new SqlConnection(connString);
            string sql = "select * from BookCategory";
            comm = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                dr = comm.ExecuteReader();
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
                conn.Close();
            }
            comboBox1.SelectedIndex = 0;
        }
    }
}
