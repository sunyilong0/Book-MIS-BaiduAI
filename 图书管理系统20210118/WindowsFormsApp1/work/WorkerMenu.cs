using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _2021._01._09_BaiduAI;

namespace WindowsFormsApp1
{
    public partial class WorkerMenu : Form
    {
        public WorkerMenu()
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

        private void button1_Click(object sender, EventArgs e)
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

        private void 图书借阅ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 注销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flag = true;
            DialogResult dr = MessageBox.Show("确 定 注 销?", "提  示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dr == DialogResult.OK)
                this.Close();
        }

        private void 添加读者信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReaderInsert readers = new ReaderInsert();
            readers.Show();
        }

        private void 修改读者信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Selectwork ru = new Selectwork();
            ru.Show();
        }

        private void 查看读者信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 借书ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!showChildrenForm("LendBooks"))
            {
                LendBooks a = new LendBooks();
                this.IsMdiContainer = true;
                a.MdiParent = this;
                a.Show();
            }
           // toolStripStatusLabel2.Text = "图书借阅";
            TopMostChildrenForm("LendBooks");
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //使用DialogResult获取OK或者其他的状态，较为方便syl
            DialogResult dr = MessageBox.Show("确 定 退 出?", "提  示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dr == DialogResult.OK)
                Application.Exit();
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (!showChildrenForm("ChangePassword"))
            {
                ChangePassword a = new ChangePassword();
                this.IsMdiContainer = true;
                a.MdiParent = this;
                a.Show();
            }
            // toolStripStatusLabel2.Text = "图书借阅";
            TopMostChildrenForm("ChangePassword");
            
        }

        private void 图书归还ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!showChildrenForm("BookBack"))
            {
                BookBack a = new BookBack();
                this.IsMdiContainer = true;
                a.MdiParent = this;
                a.Show();
            }
           
            TopMostChildrenForm("BookBack");

        }

        private void 借阅情况查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {


            if (!showChildrenForm("ReaderSelectBorrowing"))
            {
                ReaderSelectBorrowing a = new ReaderSelectBorrowing();
                this.IsMdiContainer = true;
                a.MdiParent = this;
                a.Show();
            }
            TopMostChildrenForm("ReaderSelectBorrowing");
            //////////////////////////////////////////
        }

        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("本系统由：吴天楚，孙逸龙，李家成，共同完成");
        }

        private void WorkerMenu_Load(object sender, EventArgs e)
        {

        }

        private void 添加读者面部信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FaceAdd rc = new FaceAdd();
            rc.Show();
        }
    }
}
