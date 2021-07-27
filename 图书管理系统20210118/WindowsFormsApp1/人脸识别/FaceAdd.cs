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

namespace _2021._01._09_BaiduAI
{
    public partial class FaceAdd : Form
    {
        string tocken = "";
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoDevice;

        ReaderHelper rh;        
        public FaceAdd()
        {
            InitializeComponent();
            string str = AccessToken.getAccessToken();
            Tocken tk = JsonConvert.DeserializeObject<Tocken>(str);
            this.tocken = tk.access_token;
        }
        private void NewMethod()
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
        private void button4_Click(object sender, EventArgs e)
        {
            NewMethod();
        }

        private void FaceAdd_Load(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            //Form1 form = new Form1();
            //form.ShowDialog();
            string readerID = txtID.Text;
            //拍照
            Bitmap img = videoSourcePlayer1.GetCurrentVideoFrame();
            //图片转Base64
            string imagStr = ImgHelper.ToBase64(img);
            //实例化FaceInfo对象
            FaceInfo faceInfo = new FaceInfo();
            faceInfo.image = imagStr;
            faceInfo.image_type = "BASE64";
            faceInfo.group_id = "admin";
            faceInfo.user_id = readerID;
            faceInfo.user_info = "";
            faceInfo.quality_control = "NONE";
            faceInfo.liveness_control = "NORMAL";
            faceInfo.action_type = "APPEND";
            faceInfo.face_sort_type = 0;
            FaceCommon.token = tocken;
            //调用注册方法注册人脸
            var msg = FaceCommon.add(faceInfo);
            Console.WriteLine(msg);
            //将信息写入数据库的语句wtc
            try
            {
                rh = new ReaderHelper(txtID.Text, txtName.Text, txtPhone.Text,1);   //实例化读者类
                rh.Insert();
            }
            catch (Exception ep)
            {
                MessageBox.Show("数据库出现错误" + ep);
            }
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("输入信息点击注册即可，如果要录入多张人脸，保证ID相同点击注册，即可多次录入。");
        }

        private void videoSourcePlayer1_Click(object sender, EventArgs e)
        {

        }
    }
}
