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
    public partial class AddBookCategory : Form
    {
        public AddBookCategory()
        {
            InitializeComponent();
        }

        static string connString = "Data Source=HAINUXG-B7CDF23;Initial Catalog=Library;User ID=sa;Password=sa";
        //定义连接字符串
        SqlDataReader dr;
        private void button1_Click(object sender, EventArgs e)
        {
            string name = "";
            if (textBox1.Text == "")
            {
                MessageBox.Show("图书类别名称不能为空", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                name = textBox1.Text;
                SqlConnection conn = new SqlConnection(connString);
                SqlConnection conn1 = new SqlConnection(connString);
                SqlConnection conn2 = new SqlConnection(connString);
                string sql = "select * from BookCategory";
                SqlCommand comm = new SqlCommand(sql, conn);
                DialogResult result = MessageBox.Show("是否确定添加图书类别：" + name,
                "添加确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                //弹出窗口，确认信息
                if (result == DialogResult.OK)
                {
                    try
                    {
                        conn.Open();
                        dr = comm.ExecuteReader();
                        int id = 0;
                        while (dr.Read())
                        {
                            if (dr[0] != null)
                            {
                                int ID = (int)dr[0];
                                if (ID > id) id = ID;
                            }
                        }//获取当前最大编号
                        string SQL = String.Format("Select count(*) from BookCategory where bCategoryname = '{0}' ", name);
                        conn2.Open();
                        SqlCommand comm2 = new SqlCommand(SQL, conn2);
                        int k = (int)comm2.ExecuteScalar();
                        if (k > 0)
                            MessageBox.Show("该图书类型已存在！", "添加失败", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                        {
                            string Sql = String.Format("INSERT INTO BookCategory(bCategoryid,bCategoryname) VALUES('{0}','{1}')", id + 1, name);
                            //SQL添加语句
                            SqlCommand comm1 = new SqlCommand(Sql, conn1);
                            conn1.Open();
                            int count = comm1.ExecuteNonQuery();
                            if (count > 0)
                                MessageBox.Show("添加图书类别成功", "添加成功", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                            else
                                MessageBox.Show("添加图书类别失败", "添加失败", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "操作数据库出错！", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    finally
                    {
                    
                        //dr.Close();
                        //conn.Close();
                        //conn1.Close();
                        //conn2.Close();
                        textBox1.Text = "";
                    }
                }
            }

        }
    }
}
