
namespace WindowsFormsApp1
{
    partial class ManagerManu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManagerManu));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.系统设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.注销ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工作人员管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加工作人员ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改工作人员信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图书管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图书类别管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加类别ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改类别ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询类别ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图书信息管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加图书信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改图书信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询图书信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timelabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.系统设置ToolStripMenuItem,
            this.工作人员管理ToolStripMenuItem,
            this.图书管理ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(600, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 系统设置ToolStripMenuItem
            // 
            this.系统设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.注销ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.系统设置ToolStripMenuItem.Name = "系统设置ToolStripMenuItem";
            this.系统设置ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.系统设置ToolStripMenuItem.Text = "系统设置";
            // 
            // 注销ToolStripMenuItem
            // 
            this.注销ToolStripMenuItem.Name = "注销ToolStripMenuItem";
            this.注销ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.注销ToolStripMenuItem.Text = "注销";
            this.注销ToolStripMenuItem.Click += new System.EventHandler(this.注销ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 工作人员管理ToolStripMenuItem
            // 
            this.工作人员管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加工作人员ToolStripMenuItem,
            this.修改工作人员信息ToolStripMenuItem});
            this.工作人员管理ToolStripMenuItem.Name = "工作人员管理ToolStripMenuItem";
            this.工作人员管理ToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.工作人员管理ToolStripMenuItem.Text = "工作人员管理";
            // 
            // 添加工作人员ToolStripMenuItem
            // 
            this.添加工作人员ToolStripMenuItem.Name = "添加工作人员ToolStripMenuItem";
            this.添加工作人员ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.添加工作人员ToolStripMenuItem.Text = "添加工作人员";
            this.添加工作人员ToolStripMenuItem.Click += new System.EventHandler(this.添加工作人员ToolStripMenuItem_Click);
            // 
            // 修改工作人员信息ToolStripMenuItem
            // 
            this.修改工作人员信息ToolStripMenuItem.Name = "修改工作人员信息ToolStripMenuItem";
            this.修改工作人员信息ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.修改工作人员信息ToolStripMenuItem.Text = "修改工作人员信息";
            this.修改工作人员信息ToolStripMenuItem.Click += new System.EventHandler(this.修改工作人员信息ToolStripMenuItem_Click);
            // 
            // 图书管理ToolStripMenuItem
            // 
            this.图书管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.图书类别管理ToolStripMenuItem,
            this.图书信息管理ToolStripMenuItem});
            this.图书管理ToolStripMenuItem.Name = "图书管理ToolStripMenuItem";
            this.图书管理ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.图书管理ToolStripMenuItem.Text = "图书管理";
            // 
            // 图书类别管理ToolStripMenuItem
            // 
            this.图书类别管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加类别ToolStripMenuItem,
            this.修改类别ToolStripMenuItem,
            this.查询类别ToolStripMenuItem});
            this.图书类别管理ToolStripMenuItem.Name = "图书类别管理ToolStripMenuItem";
            this.图书类别管理ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.图书类别管理ToolStripMenuItem.Text = "图书类别管理";
            this.图书类别管理ToolStripMenuItem.Click += new System.EventHandler(this.图书类别管理ToolStripMenuItem_Click);
            // 
            // 添加类别ToolStripMenuItem
            // 
            this.添加类别ToolStripMenuItem.Name = "添加类别ToolStripMenuItem";
            this.添加类别ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.添加类别ToolStripMenuItem.Text = "添加类别";
            this.添加类别ToolStripMenuItem.Click += new System.EventHandler(this.添加类别ToolStripMenuItem_Click);
            // 
            // 修改类别ToolStripMenuItem
            // 
            this.修改类别ToolStripMenuItem.Name = "修改类别ToolStripMenuItem";
            this.修改类别ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.修改类别ToolStripMenuItem.Text = "修改类别";
            this.修改类别ToolStripMenuItem.Click += new System.EventHandler(this.修改类别ToolStripMenuItem_Click);
            // 
            // 查询类别ToolStripMenuItem
            // 
            this.查询类别ToolStripMenuItem.Name = "查询类别ToolStripMenuItem";
            this.查询类别ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.查询类别ToolStripMenuItem.Text = "查询类别";
            this.查询类别ToolStripMenuItem.Click += new System.EventHandler(this.查询类别ToolStripMenuItem_Click);
            // 
            // 图书信息管理ToolStripMenuItem
            // 
            this.图书信息管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加图书信息ToolStripMenuItem,
            this.修改图书信息ToolStripMenuItem,
            this.查询图书信息ToolStripMenuItem});
            this.图书信息管理ToolStripMenuItem.Name = "图书信息管理ToolStripMenuItem";
            this.图书信息管理ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.图书信息管理ToolStripMenuItem.Text = "图书信息管理";
            // 
            // 添加图书信息ToolStripMenuItem
            // 
            this.添加图书信息ToolStripMenuItem.Name = "添加图书信息ToolStripMenuItem";
            this.添加图书信息ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.添加图书信息ToolStripMenuItem.Text = "添加图书信息";
            this.添加图书信息ToolStripMenuItem.Click += new System.EventHandler(this.添加图书信息ToolStripMenuItem_Click);
            // 
            // 修改图书信息ToolStripMenuItem
            // 
            this.修改图书信息ToolStripMenuItem.Name = "修改图书信息ToolStripMenuItem";
            this.修改图书信息ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.修改图书信息ToolStripMenuItem.Text = "修改图书信息";
            this.修改图书信息ToolStripMenuItem.Click += new System.EventHandler(this.修改图书信息ToolStripMenuItem_Click);
            // 
            // 查询图书信息ToolStripMenuItem
            // 
            this.查询图书信息ToolStripMenuItem.Name = "查询图书信息ToolStripMenuItem";
            this.查询图书信息ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.查询图书信息ToolStripMenuItem.Text = "查询图书信息";
            this.查询图书信息ToolStripMenuItem.Click += new System.EventHandler(this.查询图书信息ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            this.帮助ToolStripMenuItem.Click += new System.EventHandler(this.帮助ToolStripMenuItem_Click);
            // 
            // timelabel
            // 
            this.timelabel.AutoSize = true;
            this.timelabel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.timelabel.Location = new System.Drawing.Point(493, 7);
            this.timelabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.timelabel.Name = "timelabel";
            this.timelabel.Size = new System.Drawing.Size(53, 12);
            this.timelabel.TabIndex = 11;
            this.timelabel.Text = "时间显示";
            this.timelabel.Click += new System.EventHandler(this.timelabel_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ManagerManu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 360);
            this.Controls.Add(this.timelabel);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ManagerManu";
            this.Text = "管理人员系统";
            this.Load += new System.EventHandler(this.ManagerManu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 系统设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 注销ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 工作人员管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改工作人员信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 图书管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 图书类别管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 图书信息管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.Label timelabel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem 添加工作人员ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加类别ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改类别ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查询类别ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加图书信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改图书信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查询图书信息ToolStripMenuItem;
    }
}