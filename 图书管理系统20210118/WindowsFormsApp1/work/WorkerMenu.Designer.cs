
namespace WindowsFormsApp1
{
    partial class WorkerMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkerMenu));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.个人ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.注销ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改密码ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图书借阅ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加读者信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改读者信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图书归还ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.借书ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图书归还ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.借阅情况查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timelabel = new System.Windows.Forms.Label();
            this.添加读者面部信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.个人ToolStripMenuItem,
            this.图书借阅ToolStripMenuItem,
            this.图书归还ToolStripMenuItem,
            this.借阅情况查询ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(667, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 个人ToolStripMenuItem
            // 
            this.个人ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.注销ToolStripMenuItem,
            this.退出ToolStripMenuItem,
            this.修改密码ToolStripMenuItem});
            this.个人ToolStripMenuItem.Name = "个人ToolStripMenuItem";
            this.个人ToolStripMenuItem.Size = new System.Drawing.Size(100, 29);
            this.个人ToolStripMenuItem.Text = "个人管理";
            // 
            // 注销ToolStripMenuItem
            // 
            this.注销ToolStripMenuItem.Name = "注销ToolStripMenuItem";
            this.注销ToolStripMenuItem.Size = new System.Drawing.Size(166, 30);
            this.注销ToolStripMenuItem.Text = "注销";
            this.注销ToolStripMenuItem.Click += new System.EventHandler(this.注销ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(166, 30);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 修改密码ToolStripMenuItem
            // 
            this.修改密码ToolStripMenuItem.Name = "修改密码ToolStripMenuItem";
            this.修改密码ToolStripMenuItem.Size = new System.Drawing.Size(166, 30);
            this.修改密码ToolStripMenuItem.Text = "修改密码";
            this.修改密码ToolStripMenuItem.Click += new System.EventHandler(this.修改密码ToolStripMenuItem_Click);
            // 
            // 图书借阅ToolStripMenuItem
            // 
            this.图书借阅ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加读者信息ToolStripMenuItem,
            this.修改读者信息ToolStripMenuItem,
            this.添加读者面部信息ToolStripMenuItem});
            this.图书借阅ToolStripMenuItem.Name = "图书借阅ToolStripMenuItem";
            this.图书借阅ToolStripMenuItem.Size = new System.Drawing.Size(100, 29);
            this.图书借阅ToolStripMenuItem.Text = "读者管理";
            this.图书借阅ToolStripMenuItem.Click += new System.EventHandler(this.图书借阅ToolStripMenuItem_Click);
            // 
            // 添加读者信息ToolStripMenuItem
            // 
            this.添加读者信息ToolStripMenuItem.Name = "添加读者信息ToolStripMenuItem";
            this.添加读者信息ToolStripMenuItem.Size = new System.Drawing.Size(242, 30);
            this.添加读者信息ToolStripMenuItem.Text = "添加读者信息";
            this.添加读者信息ToolStripMenuItem.Click += new System.EventHandler(this.添加读者信息ToolStripMenuItem_Click);
            // 
            // 修改读者信息ToolStripMenuItem
            // 
            this.修改读者信息ToolStripMenuItem.Name = "修改读者信息ToolStripMenuItem";
            this.修改读者信息ToolStripMenuItem.Size = new System.Drawing.Size(242, 30);
            this.修改读者信息ToolStripMenuItem.Text = "修改读者信息";
            this.修改读者信息ToolStripMenuItem.Click += new System.EventHandler(this.修改读者信息ToolStripMenuItem_Click);
            // 
            // 图书归还ToolStripMenuItem
            // 
            this.图书归还ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.借书ToolStripMenuItem,
            this.图书归还ToolStripMenuItem1});
            this.图书归还ToolStripMenuItem.Name = "图书归还ToolStripMenuItem";
            this.图书归还ToolStripMenuItem.Size = new System.Drawing.Size(100, 29);
            this.图书归还ToolStripMenuItem.Text = "图书管理";
            // 
            // 借书ToolStripMenuItem
            // 
            this.借书ToolStripMenuItem.Name = "借书ToolStripMenuItem";
            this.借书ToolStripMenuItem.Size = new System.Drawing.Size(166, 30);
            this.借书ToolStripMenuItem.Text = "图书借阅";
            this.借书ToolStripMenuItem.Click += new System.EventHandler(this.借书ToolStripMenuItem_Click);
            // 
            // 图书归还ToolStripMenuItem1
            // 
            this.图书归还ToolStripMenuItem1.Name = "图书归还ToolStripMenuItem1";
            this.图书归还ToolStripMenuItem1.Size = new System.Drawing.Size(166, 30);
            this.图书归还ToolStripMenuItem1.Text = "图书归还";
            this.图书归还ToolStripMenuItem1.Click += new System.EventHandler(this.图书归还ToolStripMenuItem1_Click);
            // 
            // 借阅情况查询ToolStripMenuItem
            // 
            this.借阅情况查询ToolStripMenuItem.Name = "借阅情况查询ToolStripMenuItem";
            this.借阅情况查询ToolStripMenuItem.Size = new System.Drawing.Size(138, 29);
            this.借阅情况查询ToolStripMenuItem.Text = "借阅情况查询";
            this.借阅情况查询ToolStripMenuItem.Click += new System.EventHandler(this.借阅情况查询ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(62, 29);
            this.帮助ToolStripMenuItem.Text = "帮助";
            this.帮助ToolStripMenuItem.Click += new System.EventHandler(this.帮助ToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timelabel
            // 
            this.timelabel.AutoSize = true;
            this.timelabel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.timelabel.Location = new System.Drawing.Point(537, 9);
            this.timelabel.Name = "timelabel";
            this.timelabel.Size = new System.Drawing.Size(67, 15);
            this.timelabel.TabIndex = 10;
            this.timelabel.Text = "时间显示";
            // 
            // 添加读者面部信息ToolStripMenuItem
            // 
            this.添加读者面部信息ToolStripMenuItem.Name = "添加读者面部信息ToolStripMenuItem";
            this.添加读者面部信息ToolStripMenuItem.Size = new System.Drawing.Size(242, 30);
            this.添加读者面部信息ToolStripMenuItem.Text = "添加读者面部信息";
            this.添加读者面部信息ToolStripMenuItem.Click += new System.EventHandler(this.添加读者面部信息ToolStripMenuItem_Click);
            // 
            // WorkerMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 438);
            this.Controls.Add(this.timelabel);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "WorkerMenu";
            this.Text = "工作人员-操作系统";
            this.Load += new System.EventHandler(this.WorkerMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 个人ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 注销ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改密码ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 图书借阅ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 图书归还ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 借阅情况查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label timelabel;
        private System.Windows.Forms.ToolStripMenuItem 添加读者信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改读者信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 借书ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 图书归还ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 添加读者面部信息ToolStripMenuItem;
    }
}