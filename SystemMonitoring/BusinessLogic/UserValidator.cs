using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitoring.Model;
using System.Web.Script.Serialization;
using System.Net.Http;
using System.Windows.Forms;

namespace SystemMonitoring.BusinessLogic
{
    class UserValidator
    {
        
        public bool ValidateControls(Control control)
        {
            foreach(Control cc in control.Controls)
            {
                if(cc is TextBox && cc.Text.Equals(""))
                {
                    MessageBox.Show("Don't leave the field blank");
                    return false;
                }
            }
            return true;
        }

        public static HttpResponseMessage ValidateUser(Credentials credentials)
        {
            return PostData.SendToServer(credentials as Credentials,"login");
           
        }
    }
}
