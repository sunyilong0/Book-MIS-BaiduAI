using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2021._01._09_BaiduAI
{
    class FaceInfo
    {
        public string image { get; set; }
        public string image_type { get; set; }
        public string group_id { get; set; }
        public string user_id { get; set; }
        public string user_info { get; set; }
        public string quality_control { get; set; }
        public string liveness_control { get; set; }
        public string action_type { get; set; }
        public int face_sort_type { get; set; }
        public string group_id_list { get; set; }
    }
}
