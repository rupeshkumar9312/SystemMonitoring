using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemMonitoring.Model;

namespace SystemMonitoring.BusinessLogic
{
    class CaptureScreen
    {
        public string Screenshot()
        {
            string fileName = "";
            try

            {
                //MessageBox.Show("Capturing Screenshot");
                Bitmap captureBitmap = new Bitmap(1024, 768,PixelFormat.Format32bppArgb);


                Rectangle captureRectangle = Screen.AllScreens[0].Bounds;


                Graphics captureGraphics = Graphics.FromImage(captureBitmap);
                
                captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);


                //captureBitmap.Save(@"E:" + DateTime.Now.Ticks.ToString() + ".jpg");
                string path = @"D:\Project\Screenshots\";
                fileName = DateTime.Now.Ticks + ".jpg";
                captureBitmap.Save(path + fileName , ImageFormat.Jpeg);
                StaticValues.image = path + fileName;
                return fileName;
                //MessageBox.Show(StaticValues.image);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return fileName;
        }
    }
}
