using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMonitoring.Model
{
    class Screenshot
    {
        private string fileName;
        private string v;
        private string prn;
        private string response;

        public Screenshot(string fileName, string v, string prn, string response)
        {
            this.fileName = fileName;
            this.v = v;
            this.prn = prn;
            this.response = response;
        }
        
    }
}
