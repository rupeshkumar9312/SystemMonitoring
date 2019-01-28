using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMonitoring.Model
{
    class Screenshot
    {
        public string name { get; set; }
        public string time { get; set; }
        public string user { get; set; }
        public string path { get; set; }

        public Screenshot(string name, string time, string user, string path)
        {
            this.name = name;
            this.time = time;
            this.user = user;
            this.path = path;
        }
    }
}
