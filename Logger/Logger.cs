using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace FileLogger
{
    public class Logger
    {
        [DataContract]
        public class Entry
        {
            [DataMember(Name = "Date and Time")]
            public string dateTime { get; set; }
            [DataMember(Name = "Entry Class")]
            public object className { get; set; }
            [DataMember(Name = "Entry")]
            public object entry { get; set; }
            public Entry(string dateTime, object entry)
            {
                this.dateTime = dateTime;
                this.entry = entry;
                var attributes = entry.GetType().GetCustomAttributes(typeof(DataContractAttribute), false);
                if (attributes.FirstOrDefault() is DataContractAttribute dt)
                    this.className = dt.Name;
                else
                    this.className = entry.GetType().ToString();
            }
        }
        static private List<Logger> LoggerList { get; set; } = new List<Logger>();
        private List<Entry> PostList { get; set; } = new List<Entry>();
        private void AddEntry(object entry)
        {
            PostList.Add(new Entry(DateTime.Now.ToString(), entry));
        }
        private Logger(string path = "Logger")
        {
            Path = path;
        }
        ~Logger()
        {
            if(PostList.Count != 0)
                File.AppendAllText(Path, JsonConvert.SerializeObject(PostList));
        }
        /// <summary>
        /// Returns a Logger object that corresponds to the given path. Creates a new one if none exists.
        /// </summary>
        /// <param name="message">The message to be writen to the Logger</param>
        /// <param name="forceFlush">If true will post to the Logger file no matter the PostRealTime value.</param>
        /// <returns>A Logger object to the given path.</returns>
        static public Logger GetInstance(string path)
        {
            if(LoggerList.Exists(i => i.Path == path))
            {
                return LoggerList.Find(i => i.Path == path);
            }
            else
            {
                var result = new Logger(path);
                LoggerList.Add(result);
                return LoggerList.Last();
            }
        }
        /// <summary>
        /// Path to the Logger file.
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// Saves the message to be posted.
        /// </summary>
        /// <param name="message">The message to be writen to the Logger</param>
        public Logger Add(object entry)
        {
            AddEntry(entry);
            return this;
        }
        /// <summary>
        /// Writes the saved messages to the Logger file.
        /// </summary>
        public Logger Flush()
        {
            
            var fileText = File.Exists(Path) ? File.ReadAllText(Path) : "";
            var lista = JsonConvert.DeserializeObject<List<Entry>>(fileText) ?? new List<Entry>();
            var result = lista.Concat(PostList);
            File.WriteAllText(Path, JsonConvert.SerializeObject(result));
            PostList.Clear();
            return this;
        }

    }
}
