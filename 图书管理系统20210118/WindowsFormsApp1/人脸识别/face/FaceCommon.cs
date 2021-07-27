using System;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace _2021._01._09_BaiduAI
{
    class FaceCommon
    {
        public static string token { get; set; }
        // 人脸注册
        public static string add(FaceInfo info)
        {
            string host = "https://aip.baidubce.com/rest/2.0/face/v3/faceset/user/add?access_token=" + token;
            Encoding encoding = Encoding.Default;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(host);
            request.Method = "post";
            request.KeepAlive = true;
            //String str = "{\"image\":\"027d8308a2ec665acb1bdf63e513bcb9\",\"image_type\":\"FACE_TOKEN\",\"group_id\":\"group_repeat\",\"user_id\":\"user1\",\"user_info\":\"abc\",\"quality_control\":\"LOW\",\"liveness_control\":\"NORMAL\"}";
            String str = "{\"image\":\"" + info.image + "\",\"image_type\":\"" + info.image_type + "\",\"group_id\":\"" + info.group_id + "\",\"user_id\":\"" + info.user_id + "\",\"user_info\":\"" + info.user_info + "\",\"quality_control\":\"" + info.quality_control + "\",\"liveness_control\":\"" + info.liveness_control + "\"}";
            byte[] buffer = encoding.GetBytes(str);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
            string result = reader.ReadToEnd();
            Console.WriteLine("人脸注册:");
            Console.WriteLine(result);
            FaceMsg msg = JsonConvert.DeserializeObject<FaceMsg>(result);
            return result;
        }
        // 人脸搜索
        public static MatchMsg faceSearch(FaceInfo info)
        {
            string host = "https://aip.baidubce.com/rest/2.0/face/v3/search?access_token=" + token;
            Encoding encoding = Encoding.Default;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(host);
            request.Method = "post";
            request.KeepAlive = true;
            String str = "{\"image\":\"" + info.image + "\",\"image_type\":\"" + info.image_type + "\",\"group_id_list\":\"admin\",\"quality_control\":\"NONE\",\"liveness_control\":\"NONE\"}";
            byte[] buffer = encoding.GetBytes(str);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
            string result = reader.ReadToEnd();
            Console.WriteLine("人脸搜索:");
            Console.WriteLine(result);
            MatchMsg msg = JsonConvert.DeserializeObject<MatchMsg>(result);
            Console.WriteLine(msg);
            return msg;
        }
    }
}
