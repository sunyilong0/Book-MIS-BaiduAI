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
    public partial class ChangeBookCategory : Form
    {
        public ChangeBookCategory()
        {
            InitializeComponent();
        }

        string connString = @"Data Source=HAINUXG-B7CDF23;Initial Catalog=Library;User ID=sa;Password=sa";
        SqlDataReader dr;
        SqlConnection conn;

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("图书类别名称不能为空", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string name = textBox1.Text.Trim();                
                int row = dataGridView1.CurrentCell.RowIndex;     //获取当前所选数据行的索引
                string category = dataGridView1.Rows[row].Cells[1].Value.ToString();
                conn = new SqlConnection(connString);
                string sql = "update BookCategory set bCategoryname='" + name + "' where bCategoryname='" + category + "'";
                DialogResult result = MessageBox.Show("是否确定修改此图书类别",
                    "修改确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                //弹出窗口，确认信息
                if (result == DialogResult.OK)
                {
                    SqlConnection conn1 = new SqlConnection(connString);
                    string Sql = String.Format("Select count(*) from BookCategory where bCategoryname = '{0}' ", name);
                    conn1.Open();
                    SqlCommand comm2 = new SqlCommand(Sql, conn1);
                    int k = (int)comm2.ExecuteScalar();
                    if (k > 0)
                        MessageBox.Show("该图书类型已存在！", "修改失败", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        try
                        {
                            conn.Open();
                            SqlCommand comm = new SqlCommand(sql, conn);
                            int count = comm.ExecuteNonQuery();
                            if (count > 0)
                            {
                                MessageBox.Show("修改图书类别成功", "修改成功", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                                SQLFunction.RefreshDataGridView(dataGridView1, "BookCategory");
                                textBox1.Clear();
                            }
                            else
                                MessageBox.Show("修改图书类别失败", "修改失败", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "操作数据库出错！", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }
                }

            }

            conn = new SqlConnection(connString);
            string SQL = "select * from BookCategory";
            SqlCommand COMM = new SqlCommand(SQL, conn);            
            try
            {
                conn.Open();
                dr = COMM.ExecuteReader();
                while (dr.Read())
                {
                    int id = (int)dr[0];
                    string bCategoryname = dr["bCategoryname"].ToString().Trim();                    
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
        }

        private void ChangeBookCategory_Load(object sender, EventArgs e)
        {
            SQLFunction.RefreshDataGridView(dataGridView1, "BookCategory");
        }
    }
}
