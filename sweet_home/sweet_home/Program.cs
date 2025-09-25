using System;
using System.Windows.Forms;

namespace sweet_home
{
    static class Program
    {
        /// <summary>
        ///  애플리케이션의 주요 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 👉 여기서 MainForm 실행
            Application.Run(new MainForm());
        }
    }
}
