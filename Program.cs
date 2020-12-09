using System;
using System.Windows.Forms;

namespace ChouJiang
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
            // Restart 参数用来初始化数据库
            Application.Run(new Form1("Restart"));
        }
    }
}
