using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SystemMonitoring.Model;

namespace SystemMonitoring.BusinessLogic
{
    class RegisterStudent
    {
        public HttpResponseMessage GetRegister(Student student)
        {
            return PostData.SendToServer(student as Student,"register");
            //string url = "";
            //WebRequest request = WebRequest.Create(url + student.Name + "/" + student.PRN + "/" + student.Password +"/" + student.Email);
            //WebResponse response = request.GetResponse();
            //return response;

        }
    }
}
