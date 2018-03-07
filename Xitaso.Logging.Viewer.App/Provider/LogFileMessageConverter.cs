using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xitaso.Logging.Viewer.App.Model;

namespace Xitaso.Logging.Viewer.App.Provider
{
    public class LogFileMessageConverter
    {
        public const char SeparatorCharacter = '|';

        public LogEntry ConvertFromString(string message)
        {
            var values = message.Split(SeparatorCharacter);
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
