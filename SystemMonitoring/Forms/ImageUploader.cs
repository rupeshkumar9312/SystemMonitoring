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

namespace SystemMonitoring.Forms
{
    public partial class ImageUploader : Form
    {
        public ImageUploader()
        {
            InitializeComponent();
           
        }

        private void ImageUploader_Load(object sender, EventArgs e)
        {

        }
        byte[] data;
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string selectedFile = openFileDialog1.FileName;
                textBox1.Text = selectedFile;

                //FileInfo fi = new FileInfo(selectedFile);
                //long numBytes = fi.Length;
                //MessageBox.Show("File SIze " + numBytes);
                //double dLen = Convert.ToDouble(numBytes / 1000000);
                //if (dLen < 4)

                //{

                //    // set up a file stream and binary reader for the

                //    // selected file

                //    FileStream fStream = new FileStream(selectedFile,

                //    FileMode.Open, FileAccess.Read);

                //    BinaryReader br = new BinaryReader(fStream);



                //    // convert the file to a byte array

                //     data = br.ReadBytes((int)numBytes);

                //    br.Close();



                //    // pass the byte array (file) and file name to the web service

                //    //string sTmp = srv.UploadFile(data, strFile);

                //     fStream.Close();

                //    fStream.Dispose();




                //}
              
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //string boundary = "----------" + DateTime.Now.Ticks.ToString("x");

            //HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:6080/Jersey-UP-DOWN-Image-File/rest/fileservice/upload/images");

            //httpWebRequest.ContentType = "multipart/form-data; boundary=" + boundary;
            //httpWebRequest.Method = "POST";

            PostImage();
            //PostData.SendToServer(data, "image");
        }
        public void PostImage()
        {
            HttpClient httpClient = new HttpClient();
            MultipartFormDataContent form = new MultipartFormDataContent();

            byte[] imagebytearraystring = ImageFileToByteArray(@textBox1.Text);
            
            form.Add(new ByteArrayContent(imagebytearraystring, 0, imagebytearraystring.Count()), "profile_pic", "hello1.jpg");
            HttpResponseMessage response = httpClient.PostAsync("http://localhost:6080/Jersey-UP-DOWN-Image-File/rest/fileservice/upload/images", form).Result;

            httpClient.Dispose();
            string sd = response.Content.ReadAsStringAsync().Result;
            MessageBox.Show(sd);
        }

        private byte[] ImageFileToByteArray(string fullFilePath)
        {
            FileStream fs = File.OpenRead(fullFilePath);
            byte[] bytes = new byte[fs.Length];
            fs.Read(bytes, 0, Convert.ToInt32(fs.Length));
            fs.Close();
            return bytes;
        }
    }
}
