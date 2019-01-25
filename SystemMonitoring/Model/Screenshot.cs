using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMonitoring.Model
{
    class Screenshot
    {
        public string imageName { get; set; }
        public string imageTime { get; set; }
        public byte[] imageData { get; set; }
    }
}
