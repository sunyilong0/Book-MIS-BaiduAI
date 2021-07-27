using _2021._01._09_BaiduAI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
            //Application.Run(new WorkerMenu());
            //Application.Run(new ManagerManu());
            //Application.Run(new LendBooks());
            //Application.Run(new ReaderSelectBorrowing());
            //Application.Run(new BookBack());

        }
    }
}
