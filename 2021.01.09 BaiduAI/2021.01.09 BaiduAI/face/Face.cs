using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2021._01._09_BaiduAI
{
    [Serializable]
    class Face
    {
        [JsonProperty(PropertyName = "image")]
        public string Image { get; set; }
        [JsonProperty(PropertyName = "image_type")]
        public string ImageType { get; set; }
        [JsonProperty(PropertyName = "group_id_list")]
        public string GroupIdList { get; set; }
        [JsonProperty(PropertyName = "quality_control")]
        public string QualityControl { get; set; } = "NONE";
        [JsonProperty(PropertyName = "liveness_control")]
        public string LivenessControl { get; set; } = "NONE";
        [JsonProperty(PropertyName = "user_id")]
        public string UserId { get; set; }
        [JsonProperty(PropertyName = "max_user_num")]
        public int MaxUserNum { get; set; } = 1;
    }
}
