﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using DBClient.DataRecievers;
using DB.Model.Implementation;
using System.Runtime.Serialization;

namespace DBClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var form = new MainForm();
            form.ShowDialog();
        }
    }
}
