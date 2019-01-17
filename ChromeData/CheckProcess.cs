using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromeData
{
    public class CheckProcess
    {
        public bool isRunning(string processName)
        {
            Process [] process = Process.GetProcessesByName(processName);
            if(process.Length > 0)
            {
                return true;
            }
            return false;
        }
    }
}
