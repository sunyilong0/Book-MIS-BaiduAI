using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2021._01._09_BaiduAI
{
    class FaceMsg
    {
        public int error_code { get; set; }
        public string error_msg { get; set; }
        public string log_id { get; set; }
        public string timestamp { get; set; }
        public string cached { get; set; }
        public result result { get; set; }

    }
    public class result
    {
        public string face_token { get; set; }
        public location location { get; set; }
    }
    public class location
    {
        public double left { get; set; }
        public double top { get; set; }
        public double width { get; set; }
        public double height { get; set; }
        public int rotation { get; set; }
    }
    public class MatchMsg
    {
        public int error_code { get; set; }
        public string error_msg { get; set; }
        public string log_id { get; set; }
        public int timestamp { get; set; }
        public int cached { get; set; }
        public Result result { get; set; }
    }
    public class Result
    {
        public string face_token { get; set; }
        public List<user_list> user_list { get; set; }
    }
    public class user_list
    {
        public string group_id { get; set; }
        public string user_id { get; set; }
        public string user_info { get; set; }
        public double score { get; set; }
    }
}
