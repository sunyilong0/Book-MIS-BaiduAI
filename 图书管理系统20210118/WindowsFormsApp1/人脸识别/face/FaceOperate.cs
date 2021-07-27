//using _2021._01._09_BaiduAI;
//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Net;
//using System.Text;
//using System.Threading.Tasks;

//namespace _2020._12._26_程序设计基础复习项目
//{
//    class FaceOperate : IDisposable
//    {
//        public string token { get; set; }
//        /// <summary>
//        /// 注册人脸
//        /// </summary>
//        /// <param name="face"></param>
//        /// <returns></returns>
//        //public FaceMsg Add(FaceInfo face)
//        public FaceMsg Add(FaceInfo face)
//        {
//            string host = "https://aip.baidubce.com/rest/2.0/face/v3/faceset/user/add?access_token=" + token;
//            Encoding encoding = Encoding.Default;
//            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(host);
//            request.Method = "post";
//            request.KeepAlive = true;
//            String str = JsonConvert.SerializeObject(face);
//            byte[] buffer = encoding.GetBytes(str);
//            request.ContentLength = buffer.Length;
//            request.GetRequestStream().Write(buffer, 0, buffer.Length);
//            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
//            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
//            string result = reader.ReadToEnd();
//            FaceMsg msg = JsonConvert.DeserializeObject<FaceMsg>(result);
//            return msg;
//        }
//        /// <summary>
//        /// 搜索人脸
//        /// </summary>
//        /// <param name="face"></param>
//        /// <returns></returns>
//        public MatchMsg FaceSearch(Face face)
//        {
//            string host = "https://aip.baidubce.com/rest/2.0/face/v3/search?access_token=" + token;
//            Encoding encoding = Encoding.Default;
//            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(host);
//            request.Method = "post";
//            request.KeepAlive = true;
//            String str = JsonConvert.SerializeObject(face); ;
//            byte[] buffer = encoding.GetBytes(str);
//            request.ContentLength = buffer.Length;
//            request.GetRequestStream().Write(buffer, 0, buffer.Length);
//            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
//            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
//            string result = reader.ReadToEnd();
//            MatchMsg msg = JsonConvert.DeserializeObject<MatchMsg>(result);
//            return msg;
//        }
//        public void Dispose()
//        {

//        }
//    }
//}
