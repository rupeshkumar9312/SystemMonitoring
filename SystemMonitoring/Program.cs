using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemMonitoring
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Forms.Login());
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);

            //Console.WriteLine("Hello");
        }

        static void OnProcessExit(object sender, EventArgs e)
        {
            
            Console.WriteLine("I'm out of here");
        }
    }
}
