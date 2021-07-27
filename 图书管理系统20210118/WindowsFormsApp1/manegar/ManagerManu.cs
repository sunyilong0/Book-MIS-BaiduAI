using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.manegar;
using WindowsFormsApp1.work;

namespace WindowsFormsApp1
{
    public partial class ManagerManu : Form
    {
        public ManagerManu()
        {
            InitializeComponent();
        }

        public event ChildClose closeFather;
        bool flag = false;
        private bool showChildrenForm(string p_ChildrenFormName)
        {
            int i;
            //依次检测当前窗体的子窗体  
            for (i = 0; i < this.MdiChildren.Length; i++)
            {
                //判断当前子窗体的name属性值是否与传入的字符串值相同  
                if (this.MdiChildren[i].Name == p_ChildrenFormName)
                {
                    //此子窗体是目标子窗体，激活之  
                    //this.MdiChildren[i].Activate();
                    this.MdiChildren[i].WindowState = FormWindowState.Normal;
                    return true;
                }
            }
            return false;
        }


        private void TopMostChildrenForm(string p_ChildrenFormName)
        {
            int i;
            for (i = 0; i < this.MdiChildren.Length; i++)
            {
                if (this.MdiChildren[i].Name == p_ChildrenFormName)
                {
                    //此子窗体是目标子窗体，激活之  
                    this.MdiChildren[i].Activate();
                    this.MdiChildren[i].WindowState = FormWindowState.Normal;
                    this.MdiChildren[i].Show();
                    break;
                }
            }
        }

        private void 数据统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void timelabel_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now; // 声明一个DateTime的对象；  
            //获取当前的日期；  
            //string strDate = dt.ToLongDateString().ToString();  
            // 获取当前的时间；  
            string strTime = dt.ToLongTimeString().ToString();
            // 用控件显示出来；  
            timelabel.Text = strTime;
        }

        private void ManagerManu_Load(object sender, EventArgs e)
        {

        }

        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("这是一个说明文档");
        }

        private void 注销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flag = true;
            DialogResult dr = MessageBox.Show("确 定 注 销?", "提  示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dr == DialogResult.OK)
                this.Close();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //使用DialogResult获取OK或者其他的状态，较为方便syl
            DialogResult dr = MessageBox.Show("确 定 退 出?", "提  示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dr == DialogResult.OK)
                Application.Exit();
        }

        private void 重置用户密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!showChildrenForm("mChangepassword"))
            {
                ChangePassword a = new ChangePassword();
                this.IsMdiContainer = true;
                a.MdiParent = this;
                a.Show();
            }
            // toolStripStatusLabel2.Text = "图书借阅";
            TopMostChildrenForm("mChangepassword");
            
        }

        private void 添加工作人员ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!showChildrenForm("Addwork"))
            {
                Addwork a = new Addwork();
                this.IsMdiContainer = true;
                a.MdiParent = this;
                a.Show();
            }
        
            TopMostChildrenForm("Addwork");
          
        }

        private void 修改工作人员信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!showChildrenForm("Selectwork"))
            {
                Selectwork a = new Selectwork();
                this.IsMdiContainer = true;
                a.MdiParent = this;
                a.Show();
            }
            TopMostChildrenForm("Selectwork");

        }

        private void 图书类别管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 添加类别ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (!showChildrenForm("AddBookCategory"))
            {
                AddBookCategory a = new AddBookCategory();
                this.IsMdiContainer = true;
                a.MdiParent = this;
                a.Show();
            }
            TopMostChildrenForm("AddBookCategory");
        }

        private void 修改类别ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!showChildrenForm("ChangeBookCategory"))
            {
                ChangeBookCategory a = new ChangeBookCategory();
                this.IsMdiContainer = true;
                a.MdiParent = this;
                a.Show();
            }
            TopMostChildrenForm("ChangeBookCategory");
        }

        private void 修改图书信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!showChildrenForm("ChangeBookList"))
            {
                ChangeBookList a = new ChangeBookList();
                this.IsMdiContainer = true;
                a.MdiParent = this;
                a.Show();
            }
            TopMostChildrenForm("ChangeBookList");
        }

        private void 查询类别ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (!showChildrenForm("SelectBookCategory"))
            {
                SelectBookCategory a = new SelectBookCategory();
                this.IsMdiContainer = true;
                a.MdiParent = this;
                a.Show();
            }
            TopMostChildrenForm("SelectBookCategory");
        }

        private void 查询图书信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            if (!showChildrenForm("SelectBookList"))
            {
                SelectBookList a = new SelectBookList();
                this.IsMdiContainer = true;
                a.MdiParent = this;
                a.Show();
            }
            TopMostChildrenForm("SelectBookList");
        }

        private void 添加图书信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!showChildrenForm("AddBookList"))
            {
                AddBookList a = new AddBookList();
                this.IsMdiContainer = true;
                a.MdiParent = this;
                a.Show();
            }
            TopMostChildrenForm("AddBookList");
        }

    }
}
