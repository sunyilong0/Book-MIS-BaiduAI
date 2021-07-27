namespace WindowsFormsApp1
{
    partial class BookBack
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookBack));
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtReaderid = new System.Windows.Forms.TextBox();
            this.rtbRead = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnYes = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "身份证号：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(242, 10);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 18);
            this.button1.TabIndex = 1;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtReaderid
            // 
            this.txtReaderid.Location = new System.Drawing.Point(85, 10);
            this.txtReaderid.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtReaderid.Name = "txtReaderid";
            this.txtReaderid.Size = new System.Drawing.Size(146, 21);
            this.txtReaderid.TabIndex = 2;
            // 
            // rtbRead
            // 
            this.rtbRead.Location = new System.Drawing.Point(12, 84);
            this.rtbRead.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rtbRead.Multiline = true;
            this.rtbRead.Name = "rtbRead";
            this.rtbRead.Size = new System.Drawing.Size(330, 60);
            this.rtbRead.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 148);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(328, 202);
            this.dataGridView1.TabIndex = 3;
            // 
            // btnYes
            // 
            this.btnYes.Location = new System.Drawing.Point(12, 47);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(75, 23);
            this.btnYes.TabIndex = 4;
            this.btnYes.Text = "确认归还";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // BookBack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 360);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.rtbRead);
            this.Controls.Add(this.txtReaderid);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "BookBack";
            this.Text = "归还图书";
            this.Load += new System.EventHandler(this.BookBack_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtReaderid;
        private System.Windows.Forms.TextBox rtbRead;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnYes;
    }
}