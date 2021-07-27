using AForge.Video.DirectShow;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;
using System.Data.SqlClient;

namespace _2021._01._09_BaiduAI
{

    public partial class facebooklend : Form
    {
        string txtReaderid;
        string tocken = "";
        SqlConnection conn; //声明连接对象
        SqlCommand comm; //声明命令对象
        public facebooklend()
        {
            InitializeComponent();
            string str = AccessToken.getAccessToken();
            Tocken tk = JsonConvert.DeserializeObject<Tocken>(str);
            this.tocken = tk.access_token;
        }
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoDevice;

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // 获取摄像头
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                //实例化摄像头
                videoDevice = new VideoCaptureDevice(videoDevices[0].MonikerString);
                //将摄像头视频播放在控件中
                videoSourcePlayer1.VideoSource = videoDevice;
                //开启摄像头
                videoSourcePlayer1.Start();
            }
            catch
            {
                MessageBox.Show("摄像头因某些原因初始化失败");
                this.Close();
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            videoSourcePlayer1.Stop();
        }

        private void button1_Click(object sender, EventArgs e)//重新启用摄像头
        {
            //获取摄像头
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            //实例化摄像头
            videoDevice = new VideoCaptureDevice(videoDevices[0].MonikerString);
            //将摄像头视频播放在控件中
            videoSourcePlayer1.VideoSource = videoDevice;
            //开启摄像头
            videoSourcePlayer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //缺少返回最初界面的代码
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Form1 form = new Form1();
            //form.ShowDialog();

            //拍照
            Bitmap img = videoSourcePlayer1.GetCurrentVideoFrame();
            //图片转Base64
            string imagStr = ImgHelper.ToBase64(img);
            //实例化FaceInfo对象
            FaceInfo faceInfo = new FaceInfo();
            faceInfo.image = imagStr;
            faceInfo.image_type = "BASE64";
            faceInfo.group_id = "admin";
            faceInfo.user_id = "432520000000000014";
            faceInfo.user_info = "";
            faceInfo.quality_control = "NONE";
            faceInfo.liveness_control = "NONE";
            faceInfo.action_type = "APPEND";
            faceInfo.face_sort_type = 0;
            FaceCommon.token = tocken;
            //调用注册方法注册人脸
            var msg = FaceCommon.add(faceInfo);
            Console.WriteLine(msg);

        }
        private void NewMethod()
        {
            try
            {
                //获取图片 拍照
                Bitmap img = videoSourcePlayer1.GetCurrentVideoFrame();
                //关闭相机
                //videoSourcePlayer1.Stop();
                //图片转Base64
                string imagStr = ImgHelper.ToBase64(img);
                FaceInfo faceInfo = new FaceInfo();
                faceInfo.image = imagStr;
                faceInfo.image_type = "BASE64";
                faceInfo.group_id_list = "admin";
                try
                {
                    FaceCommon.token = tocken;
                    //调用查找方法
                    MatchMsg msg = FaceCommon.faceSearch(faceInfo);
                    if (msg.result.user_list[0].score > 90)
                    {
                        MessageBox.Show("登陆成功,用户ID为：" + msg.result.user_list[0].user_id + "。请扫描书本继续操作");
                        label1.Text = ("当前登录用户ID：" + msg.result.user_list[0].user_id);
                        txtReaderid = msg.result.user_list[0].user_id;
                        findbook.Enabled = true;//查找按钮
                                                //button1.Enabled = true;//重新登录
                        buttonYESlend.Enabled = true;//确定借阅
                    }
                    else if (msg.result.user_list[0].score < 90)
                    {
                        MessageBox.Show("人脸对不上");
                    }
                }
                catch (Exception e)
                {
                    DialogResult dialog = MessageBox.Show("人员不存在,错误提示" + e, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (dialog == DialogResult.OK)
                    {
                        this.Close();
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("无法获取人脸");
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            NewMethod();
        }

        private void videoSourcePlayer1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)  //查找书籍按钮
        {
            //数据库代码,查找书籍，并显示在dataGridView1中  wtc
            if (txtISBN.Text == "")
            {
                MessageBox.Show("请输入ISBN");
            }
            else
            {
                try
                {
                    String CommandText = "SELECT * FROM BookList WHERE ISBN =" + "'" + txtISBN.Text + "'";
                    int k = DBHelper.ExecuteCommand(CommandText);

                    if (k <= 0)
                    {
                        DataSet ds = DBHelper.ExecuteReTable("SELECT * FROM BookList WHERE ISBN =" + "'" + txtISBN.Text + "'", "BookList");
                        //this.dataGridView1.DataSource = ds;
                        dataGridView1.DataSource = ds.Tables[0];

                    }
                    else
                    {
                        MessageBox.Show("未找到此书籍");
                    }
                }
                catch (SqlException err)
                {
                    MessageBox.Show(err.ToString());
                }

            }

        }

        private void buttonYESlend_Click(object sender, EventArgs e)  //确定借阅
        {
            string sql;
            string connString = @"Data Source=HAINUXG-B7CDF23;Initial Catalog=Library;User ID=sa;Password=sa";
            conn = new SqlConnection(connString);
            comm = new SqlCommand();
            comm.Connection = conn;
            conn.Open();
            string Rid = txtReaderid;
            string BISBN = txtISBN.Text.Trim();
            string d = dateTimePicker1.Value.ToString();

            if (txtReaderid == "" || txtISBN.Text.Trim() == "")
                MessageBox.Show("请完整填写信息！", "借阅", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                sql = String.Format("Select count(*) from BookList where ISBN = '{0}'", BISBN);
                comm.CommandText = sql;
                int kkk = (int)comm.ExecuteScalar();


                if (kkk <= 0)
                    MessageBox.Show("ISBN查找失败！\n   请查对", "借阅", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    sql = String.Format("Select count(*) from BookList where ISBN = '{0}' and Lendnum < num", BISBN);
                    comm.CommandText = sql;
                    kkk = (int)comm.ExecuteScalar();
                    if (kkk <= 0)
                        MessageBox.Show("该书已无库存！", "借阅", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        sql = String.Format("Select count(*) from Reader where Rid = '{0}'", Rid);
                        comm.CommandText = sql;
                        kkk = (int)comm.ExecuteScalar();
                        if (kkk <= 0)
                            MessageBox.Show("身份证号查找失败！\n   请查对", "借阅", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                        {
                            //dateTimePicker2.Text = DateTime.Parse(DateTime.Now.ToString(dateTimePicker1.Text)).AddDays(90).ToShortDateString();
                            DateTime dt = DateTime.Now; //获取当前的日期； 
                            SqlDataReader dr;
                            sql = String.Format("Select count(*) from BookLendList where Rid = '{0}' and ISBN = '{1}' and isback = 0", Rid, BISBN);
                            comm.CommandText = sql;
                            int k2 = (int)comm.ExecuteScalar();
                            if (k2 > 0)
                            {
                                MessageBox.Show("该读者已借此书，且并未归还！");
                            }
                            else
                            {
                                //MessageBox.Show("Pass");
                                sql = String.Format("Select count(*) from BookLendList where Rid = '{0}' and BackTime < '{1}' and isback = 0", Rid, dt);
                                comm.CommandText = sql;
                                int k = (int)comm.ExecuteScalar();
                                double pm = 0;

                                sql = String.Format("Select * from Reader, ReaderCategory where Reader.Rid = '{0}'", Rid);
                                comm.CommandText = sql;
                                dr = comm.ExecuteReader();
                                dr.Read();


                                int m = (int)dr["Rbnum"];

                                //dateTimePicker2.Text = DateTime.Parse(DateTime.Now.ToString(dateTimePicker1.Text)).AddDays(ad).ToShortDateString();
                                dr.Close();
                                if (k <= 0 && 0 < m)  //本应该为已借的书n小于m的，但是暂未实现
                                {

                                    sql = String.Format("Select * from BookList, Bookcategory where ISBN = '{0}' and BookList.bCategoryid = Bookcategory.bCategoryid", BISBN);
                                    comm.CommandText = sql;
                                    dr = comm.ExecuteReader();
                                    dr.Read();


                                    dr.Close();
                                    DialogResult result = MessageBox.Show("确定借阅？", "借阅", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                                    if (result == DialogResult.OK)
                                    {
                                        sql = String.Format("Insert into BookLendList values('{0}','{1}','{2}', 0,0, 0, 0)", Rid, BISBN, d);
                                        comm.CommandText = sql;
                                        int kk = (int)comm.ExecuteNonQuery();
                                        sql = String.Format("Update BookList set lendnum = lendnum + 1  where ISBN = '{0}'", BISBN);
                                        comm.CommandText = sql;
                                        kk += (int)comm.ExecuteNonQuery();

                                        if (kk == 2)
                                            MessageBox.Show("借阅成功！", "借阅", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        else
                                            MessageBox.Show("借阅失败！", "借阅", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else if (k > 0)
                                {

                                    MessageBox.Show("该读者存在超期未还书籍", "借阅失败", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    sql = String.Format("Select * from BookList, BookLendList where Rid = '{0}' and BookList.ISBN = BookLendList.ISBN and BackTime < '{1}' and isback = 0", Rid, dt);
                                    comm.CommandText = sql;
                                    dr = comm.ExecuteReader();

                                    while (dr.Read())
                                    {
                                        string ddd = dr["BackTime"].ToString();
                                        string a = ddd.Substring(0, ddd.IndexOf("/"));
                                        int t = ddd.IndexOf("/");
                                        ddd = ddd.Remove(t, 1);
                                        ddd = ddd.Insert(t, "a");
                                        int t1 = ddd.IndexOf("a");
                                        t = ddd.IndexOf("/") - 1;
                                        string b = ddd.Substring(t1 + 1, t - t1);
                                        if (b.Length == 1)
                                            b = "0" + b;
                                        t1 = ddd.IndexOf(" ") - 1;
                                        string c = ddd.Substring(t + 2, t1 - t - 1);
                                        if (c.Length == 1)
                                            c = "0" + c;
                                        System.Globalization.DateTimeFormatInfo dtFormat = new System.Globalization.DateTimeFormatInfo();
                                        dtFormat.ShortDatePattern = "yyyy/MM/dd";
                                        DateTime dd = Convert.ToDateTime(a + "/" + b + "/" + c, dtFormat);
                                        TimeSpan d3 = dt.Subtract(dd);
                                        pm += (double)d3.Days * 0.1;

                                    }

                                    dr.Close();
                                }
                                else if (10 >= m)
                                {

                                    MessageBox.Show("该读者借阅数目超限", "借阅失败", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }//正常
                        }//身份证号查阅失败
                    }//无库存
                }//ISBN查找失败
            }
            conn.Close();

        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            string connString = "Data Source=HAINUXG-B7CDF23;Initial Catalog=Library;User ID=sa;Password=sa";
            conn = new SqlConnection(connString);
            comm = new SqlCommand();
            comm.Connection = conn;
            string sql;
            bool flag = false;
            float pay;
            //bool Ban = true;
            string Rid = txtReaderid;
            string BISBN;
            DateTime dt = DateTime.Now;
            bool ft = true;
            int ad;
            int KP = 0;
            conn.Open();
            Rid = txtReaderid.Trim();
            sql = String.Format("Select count(*) from Reader where Rid = '{0}'", Rid);
            comm.CommandText = sql;
            int kkk = (int)comm.ExecuteScalar();
            conn.Close();
            if (kkk <= 0)
                MessageBox.Show("身份证号查找失败！\n   请查对", "还书失败", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                sql = String.Format("select b.ISBN as ISBN, b.BookName as 书名,a.LendTime as 借阅时间,a.BackTime as 应还时间 "
            + "from bookLendList as a,BookList as b,Reader as c where a.ISBN=b.ISBN and a.Rid=c.Rid and a.Rid='{0}' and a.isback = 0", Rid);
                try
                {
                    conn.Open();
                    conn = new SqlConnection(connString);
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataSet ds = new DataSet("MyData");
                    da.Fill(ds, "MyData");
                    if (ft == true)
                    {
                        DataColumn column = new DataColumn("选择", typeof(bool));
                        ds.Tables["MyData"].Columns.Add(column);
                        dataGridView1.DataSource = ds.Tables[0];
                        dataGridView1.Columns[0].ReadOnly = true;
                        dataGridView1.Columns[1].ReadOnly = true;
                        dataGridView1.Columns[2].ReadOnly = true;
                        //dataGridView1.Columns[3].ReadOnly = true;
                        this.dataGridView1.Columns["选择"].DisplayIndex = Convert.ToInt32(0);
                        dataGridView1.Columns[4].Width = 50;
                        ft = false;
                    }
                    sql = String.Format("Select * from Reader, ReaderCategory where Reader.Rid = '{0}' and Reader.Rcategoryid = ReaderCategory.Rcategoryid", Rid);
                    comm.CommandText = sql;
                    SqlDataReader dr;
                    dr = comm.ExecuteReader();
                    dr.Read();
                    rtbRead.Clear();
                    rtbRead.Text = "身份证号：" + dr[0].ToString() + "\n姓名：" + dr["Rname"].ToString()
                        + "\n读者类别：" + dr["Rcategoryname"].ToString()
                        + "\n已借阅数目：" + "1";
                    ad = (int)dr["Rday"];
                    dr.Close();
                    sql = String.Format("Select count(*) from BookLendList where Rid = '{0}' and BackTime < '{1}' and isBack = 0", Rid, dt);
                    comm.CommandText = sql;
                    int k = (int)comm.ExecuteScalar();
                    KP = k;
                    rtbRead.Text += k.ToString();
                    btnYes.Enabled = true;
                    MessageBox.Show("还书成功！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "操作数据库出错！", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
