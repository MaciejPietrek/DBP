using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    class Logger
    {
        public Logger(string logText)
        {
            var directory = Directory.GetCurrentDirectory();
            using (var writer = new StreamWriter(directory + "\\log.txt"))
            {
                writer.WriteLine(logText);
            }
        }
    }
}
