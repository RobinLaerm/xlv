using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xitaso.Logging.Viewer.App.Model
{
    public class LogLevelFilter
    {
        public LogLevelFilter()
        {
            FilterSettings = new List<LogLevelFilterSetting>();
        }

        public List<LogLevelFilterSetting> FilterSettings { get; set; }

        public void AddFilterSetting(LogLevelFilterSetting filterSetting)
        {
            FilterSettings.Add(filterSetting);
        }

        public static LogLevelFilter CreateDefaultFilter()
        {
            var filter = new LogLevelFilter();
            filter.AddFilterSetting(new LogLevelFilterSetting("Fatal", "Purple"));
            filter.AddFilterSetting(new LogLevelFilterSetting("Error", "Red"));
            filter.AddFilterSetting(new LogLevelFilterSetting("Warn", "Yellow"));
            filter.AddFilterSetting(new LogLevelFilterSetting("Info", "Green"));
            filter.AddFilterSetting(new LogLevelFilterSetting("Debug", "Gray"));
            return filter;
        }
    }
}
