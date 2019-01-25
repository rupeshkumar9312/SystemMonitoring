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
using SystemMonitoring.Model;

namespace SystemMonitoring.Forms
{
    public partial class Welcome : Form
    {
        ChromeHistory ch;
        private int _ticks;
        public Welcome()
        {
            InitializeComponent();

            ch = new ChromeHistory(StaticValues.prn);
            //CheckProcess cp = new CheckProcess();
            //if(!cp.isRunning("chrome"))
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
                     
                    List<HistoryItem> history = ch.GetHistory(StaticValues.prn);
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

        private void Welcome_FormClosing(object sender, FormClosingEventArgs e)
        {
            Console.WriteLine("Application Closed");
           
            Application.Exit();
        }
    }
}
