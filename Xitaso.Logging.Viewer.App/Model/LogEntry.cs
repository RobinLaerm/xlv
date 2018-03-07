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

    }
}
