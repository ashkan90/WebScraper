using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraper.Workers
{
    class FileWriter
    {
        public static void Write(string[] data, string path)
        {
            File.WriteAllLines(path, data);
        }
    }
}
