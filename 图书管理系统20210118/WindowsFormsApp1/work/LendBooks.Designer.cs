
namespace WindowsFormsApp1
{
    partial class LendBooks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LendBooks));
            this.btnYes = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.rtbBook = new System.Windows.Forms.RichTextBox();
            this.rtbRead = new System.Windows.Forms.RichTextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtReaderid = new System.Windows.Forms.TextBox();
            this.txtbookISBN = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnYes
            // 
            this.btnYes.Location = new System.Drawing.Point(356, 328);
            this.btnYes.Margin = new System.Windows.Forms.Padding(4);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(100, 29);
            this.btnYes.TabIndex = 22;
            this.btnYes.Text = "借阅(&Y)";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click_1);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(77, 328);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 29);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // rtbBook
            // 
            this.rtbBook.Location = new System.Drawing.Point(273, 104);
            this.rtbBook.Margin = new System.Windows.Forms.Padding(4);
            this.rtbBook.Name = "rtbBook";
            this.rtbBook.Size = new System.Drawing.Size(255, 215);
            this.rtbBook.TabIndex = 17;
            this.rtbBook.Text = "";
            // 
            // rtbRead
            // 
            this.rtbRead.Location = new System.Drawing.Point(11, 104);
            this.rtbRead.Margin = new System.Windows.Forms.Padding(4);
            this.rtbRead.Name = "rtbRead";
            this.rtbRead.Size = new System.Drawing.Size(253, 215);
            this.rtbRead.TabIndex = 18;
            this.rtbRead.Text = "";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Location = new System.Drawing.Point(380, 10);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(148, 25);
            this.dateTimePicker1.TabIndex = 16;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // txtReaderid
            // 
            this.txtReaderid.Location = new System.Drawing.Point(119, 66);
            this.txtReaderid.Margin = new System.Windows.Forms.Padding(4);
            this.txtReaderid.Name = "txtReaderid";
            this.txtReaderid.Size = new System.Drawing.Size(132, 25);
            this.txtReaderid.TabIndex = 15;
            // 
            // txtbookISBN
            // 
            this.txtbookISBN.Location = new System.Drawing.Point(119, 14);
            this.txtbookISBN.Margin = new System.Windows.Forms.Padding(4);
            this.txtbookISBN.Name = "txtbookISBN";
            this.txtbookISBN.Size = new System.Drawing.Size(132, 25);
            this.txtbookISBN.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(285, 18);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "借阅日期：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "读者账号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "图书ISBN号：";
            // 
            // LendBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 369);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.rtbBook);
            this.Controls.Add(this.rtbRead);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.txtReaderid);
            this.Controls.Add(this.txtbookISBN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "LendBooks";
            this.Text = "借书界面";
            this.Load += new System.EventHandler(this.LendBooks_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.RichTextBox rtbBook;
        private System.Windows.Forms.RichTextBox rtbRead;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txtReaderid;
        private System.Windows.Forms.TextBox txtbookISBN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}