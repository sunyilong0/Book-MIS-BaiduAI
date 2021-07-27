using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2021._01._09_BaiduAI
{
    class ImgHelper
    {
        /// <summary>
        /// 转换图片
        /// </summary>
        /// <param name="bmp"></param>
        /// <returns></returns>
        public static string ToBase64(Bitmap bmp)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] arr = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(arr, 0, (int)ms.Length);
                ms.Close();
                String strbaser64 = Convert.ToBase64String(arr);
                return strbaser64;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ImgToBase64String 转换失败 Exception:" + ex.Message);
                return "";
            }
        }
    }
}
