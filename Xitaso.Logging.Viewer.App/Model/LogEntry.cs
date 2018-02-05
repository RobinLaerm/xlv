using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xitaso.Logging.Viewer.App.Model
{
    public class LogEntry
    {
        public DateTime CreationTime { get; set; }

        public string Message { get; set; }

        public string MachineName { get; set; }

        public string LoggerName { get; set; }

        public string LogLevel { get; set; }

        public int Counter { get; set; }

        public static LogEntry Parse(string contentAsString)
        {
            var values = contentAsString.Split('|');
            if (values.Length < 2) return null;
            LogEntry entry = new LogEntry()
            {
                Counter = Convert.ToInt32(values[0]),
                CreationTime = Convert.ToDateTime(values[1]),
                MachineName = values[2],
                LoggerName = values[4],
                LogLevel = values[5],
                Message = values[6]
            };
            return entry;
        }
    }
}
