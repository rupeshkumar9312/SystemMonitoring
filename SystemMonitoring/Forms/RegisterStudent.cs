using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemMonitoring.Model;
using SystemMonitoring.BusinessLogic;
using BusinessLogic;
using System.Diagnostics;
using System.Net.Http;

namespace SystemMonitoring.Forms
{
    public partial class RegisterStudent : Form
    {
        public RegisterStudent()
        {
            InitializeComponent();
            //this.ShowInTaskbar = false;
            //this.ControlBox = false;
            //ProcessStartInfo info = new ProcessStartInfo();
            //info.FileName = "ipconfig";
            //info.Arguments = "/release"; // or /release if you want to disconnect
            //info.WindowStyle = ProcessWindowStyle.Hidden;
            //Process p = Process.Start(info);
            //p.WaitForExit();

        }
        private void Form1_SizeChanged(object sender, EventArgs e)
        {


        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            //ProcessStartInfo info = new ProcessStartInfo();
            //info.FileName = "ipconfig";
            //info.Arguments = "/renew"; // or /release if you want to disconnect
            //info.WindowStyle = ProcessWindowStyle.Hidden;
            //Process p = Process.Start(info);
            //p.WaitForExit();


            string name = txtName.Text;
            string password = txtPassword.Text;
            string confirmpPassword = txtConfirmPwd.Text;
            string prn = txtPRN.Text;
            string email = txtEmail.Text;
            string course = comboCourse.Text;
            string batch = txtBatch.Text;


            UserValidator uv = new UserValidator();
            bool check = uv.ValidateControls(groupRegistration);

            if (check)
            {
                if (!password.Equals(confirmpPassword))
                {
                    MessageBox.Show("Password do not match");
                    return;
                }

                Student student = new Student(prn, name, password, email,course,batch);

                BusinessLogic.RegisterStudent rs = new BusinessLogic.RegisterStudent();
                HttpResponseMessage res = rs.GetRegister(student);
                int status = (int)res.StatusCode;
                if (status == 200)
                {
                    MessageBox.Show("Register Successfull");
                    //RestClient rc = new RestClient();
                    //rc.endPoint = new ApiUrl().createTable + prn;
                    //rc.httpMethod = httpVerb.GET;
                    //string response = rc.makeRequest();
                    //MessageBox.Show(response);
                    //Console.WriteLine("RESPONSE " + response);
                    //if (response.Equals("success"))
                    //{
                        Login login = new Login();
                        this.Hide();
                        login.Show();
                    //}
                    //else if (response.Equals("failed"))
                    //{
                    //    MessageBox.Show("Already registered");
                    //}
                }
                //else if (status == 204)
                //{
                //    MessageBox.Show("Already Registered");
                //}

            }
            //RegisterStudent_SizeChanged(sender, e);

            if (password.Equals(confirmpPassword))
            {


                /*to be added later working fine*/
                //WebRequest request = WebRequest.Create("http://localhost:1234/item/" + name + "/" + prn + "/" + password);
                //WebResponse response = request.GetResponse();

                //BusinessLogic.CaptureScreen.Screenshot();
                if (this.WindowState == FormWindowState.Minimized)
                {
                    MessageBox.Show("Clicked");
                    Hide();
                    notifyIcon1.Visible = true;

                }
            }


        }


        private void groupRegistration_Enter(object sender, EventArgs e)
        {

        }

        private void RegisterStudent_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
