using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMonitoring.Model
{
    public class ApiUrl
    {
        public string mainUrl = "http://localhost:6080/WebApi/student/";
        public string forgotPassword = "http://localhost:6080/WebApi/forgotpassword/";
        public string createTable = "http://localhost:6080/WebApi/create/";
        public string checkPrn = "http://localhost:6080/WebApi/checkprn/";
        public string register = "http://localhost:6080/WebApi/student/register";
        public string login = "http://localhost:6080/WebApi/student/login";
        public string history = "http://localhost:6080/WebApi/url";
    }
}
