using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace _2021._01._09_BaiduAI
{
    class AccessToken
    {
        // 调用getAccessToken()获取的 access_token建议根据expires_in 时间 设置缓存
        // 返回token示例
        public static string TOKEN = "24.ddb44b9a5e904f9201ffc1999daa7670.2592000.1578837249.282335-18002137";

        // 百度云中开通对应服务应用的 API Key 建议开通应用的时候多选服务
        private static string clientId = "kGq7pEydZbInZtg4kmNNOVMs";
        // 百度云中开通对应服务应用的 Secret Key
        private static string clientSecret = "H2xCHve9IEXjkPBQay7nFIhVOVrGM6Ux";

        public static string getAccessToken()
        {
            string authHost = "https://aip.baidubce.com/oauth/2.0/token";
            HttpClient client = new HttpClient();
            List<KeyValuePair<String, String>> paraList = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "client_credentials"),
                new KeyValuePair<string, string>("client_id", clientId),
                new KeyValuePair<string, string>("client_secret", clientSecret)
            };

            HttpResponseMessage response = client.PostAsync(authHost, new FormUrlEncodedContent(paraList)).Result;
            string result = response.Content.ReadAsStringAsync().Result;
            return result;
        }
    }
}
