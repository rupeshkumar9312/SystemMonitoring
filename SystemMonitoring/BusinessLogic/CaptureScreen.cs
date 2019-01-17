using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemMonitoring.BusinessLogic
{
    class CaptureScreen
    {
        public void Screenshot()
        {
            try

            {
                
                Bitmap captureBitmap = new Bitmap(1024, 768,PixelFormat.Format32bppArgb);


                Rectangle captureRectangle = Screen.AllScreens[0].Bounds;


                Graphics captureGraphics = Graphics.FromImage(captureBitmap);
                
                captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);


                //captureBitmap.Save(@"E:" + DateTime.Now.Ticks.ToString() + ".jpg");
                string path = @"E:\DotNetTraining\Project\Screenshots\";
                string fileName = DateTime.Now.Ticks + ".jpg";
                captureBitmap.Save(path + fileName , ImageFormat.Jpeg);

                MessageBox.Show(path + fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
