using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xitaso.Logging.Viewer.App.Model;

namespace Xitaso.Logging.Viewer.App.ViewModels
{
    public class LogLevelFilterViewModel : Screen
    {
        private LogLevelFilter _logLevelFilter;

        public LogLevelFilterViewModel()
        {
            _logLevelFilter = LogLevelFilter.CreateDefaultFilter();
            FilterSettings = new BindableCollection<LogLevelFilterSettingViewModel>();
            FilterSettings.AddRange(_logLevelFilter.FilterSettings.Select(fs => new LogLevelFilterSettingViewModel(fs)));
        }

        public BindableCollection<LogLevelFilterSettingViewModel> FilterSettings { get; }

        public List<LogEntry> Apply(List<LogEntry> newEntries)
        {
            List<LogEntry> filteredList = new List<LogEntry>();
            foreach (var entry in newEntries)
            {
                var filterSetting = FilterSettings.FirstOrDefault(fs => fs.Name.Equals(entry.LogLevel));
                if (filterSetting == null || filterSetting.IsActive == true)
                {
                    filteredList.Add(entry);
                }
            }
            return filteredList;
        }
    }
}
