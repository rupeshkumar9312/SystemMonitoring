using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromeData
{
    public class FileUtil
    {
        public static void Write(long time)
        {
            string[] lines = new string[] { time.ToString() };
            Console.WriteLine("writing");
            File.WriteAllLines("time.txt", lines);
            Console.WriteLine("done");
        }

        public static long Read()
        {
            string text = File.ReadAllText("time.txt");
            Console.WriteLine(text);
            return Convert.ToInt64(text);
        }
    }
}
