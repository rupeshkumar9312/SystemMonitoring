using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMonitoring.Model
{
    class Credentials
    {
        public String PRN { get; set; }
        public String Password { get; set; }

        public Credentials(string pRN, string password)
        {
            PRN = pRN;
            Password = password;
        }
    }
}
