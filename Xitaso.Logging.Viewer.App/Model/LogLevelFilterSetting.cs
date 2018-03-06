using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xitaso.Logging.Viewer.App.Model
{
    /// <summary>
    /// Filter setting for log level
    /// </summary>
    public class LogLevelFilterSetting
    {
        public LogLevelFilterSetting(string name, string colorName, bool isActive = true)
        {
            this.Name = name;
            this.ColorName = colorName;
            this.IsActive = isActive;
        }

        /// <summary>
        /// Activates or deactivates the filter.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Name of the LogLevel the filter belongs to.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Name of the color for the log levels.
        /// </summary>
        public string ColorName { get; set; }
    }
}
