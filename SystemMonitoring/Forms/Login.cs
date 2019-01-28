using BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemMonitoring.BusinessLogic;
using SystemMonitoring.Model;

namespace SystemMonitoring.Forms
{
    public partial class Login : Form
    {
        private string v1;
        private string v2;

        public Login()
        {
            InitializeComponent();
            
        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
          
            //var client = new HttpClient();
            //var content = new MultipartFormDataContent();
            //content.Add(new StreamContent(File.Open("C:\\Users\\Rupesh\\Desktop\\CC.jpg", FileMode.Open)), "Image", "Image.png");
            //content.Add(new StringContent("Place string content here"), "Content-Id in the HTTP");
            //var result = client.PostAsync("http://localhost:8080/RestfulFileUploadExample/rest/files/upload", content);
            //Console.WriteLine(result.Result.ToString());

            //byte[] arr = imageToByteArray(Image.FromFile("C:\\Users\\Rupesh\\Desktop\\CC.jpg"));

            //Screenshot sc = new Screenshot();
            //sc.imageData = arr;
            //sc.imageName = "sample.jpg";
            //sc.imageTime = "current";
            //PostData.SendToServer(sc, "image");

            UserValidator uv = new UserValidator();
            if (uv.ValidateControls(groupLogin))
            {
                string prn = txtPRN.Text;
                string password = txtPassword.Text;
                HttpResponseMessage response = null;

                response = UserValidator.ValidateUser(new Credentials(prn, password));
                Console.WriteLine("Inside Try");
                try
                {
                    if ((int)response.StatusCode == 200)
                    {
                        StaticValues.prn = prn;
                        this.Hide();
                        new Welcome().Show();

                    }
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("Inside Catch");
                    RestClient rc = new RestClient();
                    rc.endPoint = new ApiUrl().checkPrn + prn;
                    rc.httpMethod = httpVerb.GET;
                    string res = rc.makeRequest();
                    if (res.Equals("success"))
                    {

                        MessageBox.Show("Incorrect Password");
                        return;
                    }
                    //        MessageBox.Show("Please register yourself");


                    //    }




                    //    //Console.WriteLine("Inside Catch");
                    //    //RestClient rc = new RestClient();
                    //    //rc.endPoint = "http://localhost:6080/WebApi/checkprn/" + prn;
                    //    //rc.httpMethod = httpVerb.GET;
                    //    //string res = rc.makeRequest();
                    //    //MessageBox.Show(res);


                    //    //MessageBox.Show(response.ToString());
                    //    //if ((int)response.StatusCode == 200)
                    //    //{
                    //    //    this.Hide();
                    //    //    new Welcome().Show();

                    //    //}
                    //    //else
                    //    //{


                    //    //}
                    //}


                    //RestClient rs = new RestClient();
                    //string url = "http://localhost:6080/WebApi/student/";
                    //rs.httpMethod = httpVerb.GET;

                    //rs.endPoint = url + "180851920077";
                    ////MessageBox.Show(rs.endPoint);
                    //String response = rs.makeRequest();
                    //MessageBox.Show(response.ToString());


                    //string username = Environment.UserName;
                    //string domain = Environment.UserDomainName;

                    //string prn = txtPRN.Text;
                    //string password = txtPassword.Text;

                    //Credentials credentials = new Credentials(prn, password);

                    //UserValidator.ValidateUser(credentials);
                    //Welcome welcome = new Welcome();

                }
            }
        }

        private void lblForgotPwd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txtPRN.Text != null)
            {
                RestClient rc = new RestClient();
                ApiUrl url = new ApiUrl();

                rc.endPoint = url.forgotPassword + txtPRN.Text;
                rc.httpMethod = httpVerb.GET;
                MessageBox.Show(rc.makeRequest());

            }
            else
                MessageBox.Show("Please Enter PRN number");
        }

        private void lbl_egister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterStudent rs = new RegisterStudent();
            this.Hide();
            rs.Show();

        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("Form Closed");
        }
    }
}
