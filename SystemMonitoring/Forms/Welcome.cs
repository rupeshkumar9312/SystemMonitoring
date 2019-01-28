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
using System.Diagnostics;
using System.IO;

namespace SystemMonitoring.Forms
{
    public partial class Welcome : Form
    {
        ChromeHistory ch;
        private int _ticks;
        private int _ticksImage; 
        public Welcome()
        {
            InitializeComponent();
            CheckProcess process = new CheckProcess();
            //if(process.isRunning("chrome"))
            //{
            //    Process [] pr = Process.GetProcessesByName("chrome");
            //    foreach (Process p in pr)
            //        p.Kill();
            //}
            again:
            try
            {
                if(new CheckProcess().isRunning("chrome"))
                {
                    MessageBox.Show("Please relaunch your chrome...");
                    goto again;
                }
                ch = new ChromeHistory(StaticValues.prn);
                //CheckProcess cp = new CheckProcess();
                //if(!cp.isRunning("chrome"))
                ch.SaveLastTime();
                timer1.Start();
                timer2.Start();

                this.WindowState = FormWindowState.Minimized;
            }catch(Exception ex)
            {
                MessageBox.Show("Please relaunch your chrome");
                goto again;
            }
            
            
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

                        //CaptureScreen cs = new CaptureScreen();
                        //cs.Screenshot();
                        //string response = PostData.SendFileToServer(StaticValues.image);
                        //DateTime dt = DateTime.Now;
                        //Console.WriteLine("Response " + response);
                    }
                }
                this.Text = "Done";
                _ticks = 0;

              
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

        private void timer2_Tick(object sender, EventArgs e)
        {
            _ticksImage++;
            //this.Text = _ticksImage.ToString();
            if (_ticksImage == 10)
            {
                CaptureScreen cs = new CaptureScreen();
                string fileName = cs.Screenshot();
                string response = PostData.SendFileToServer(StaticValues.image);
                DateTime dt = DateTime.Now;
                Screenshot sc = new Screenshot(fileName, DateTime.Now.ToString(), StaticValues.prn, response);
                PostData.SendToServer(sc, "screenshot");
                Console.WriteLine("Response " + response);

                MessageBox.Show(_ticksImage.ToString());
                File.Delete(response);
                _ticksImage = 0;
            }

        }

        private void Welcome_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon1.Visible = true;
                //notifyIcon1.ShowBalloonTip(500);
                this.Hide();
            }

            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon1.Visible = false;
            }
        }
    }
}
