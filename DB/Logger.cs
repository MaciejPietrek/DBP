﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    static class Logger
    {
        static public void Log(string logText)
        {
			/*if(System.Configuration.ConfigurationSettings.AppSettings.GetValues("logOn")[0] == "true")
			{
				var directory = Directory.GetCurrentDirectory();
				using (var writer = new StreamWriter(directory + "\\log.txt"))
				{
					writer.WriteLine(logText);
				}
			}*/
            
        }
    }
}
