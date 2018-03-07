using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;
using Xitaso.Logging.Viewer.App.Converter;
using Xitaso.Logging.Viewer.App.Model;
using Xitaso.Logging.Viewer.App.Utilities;

namespace Xitaso.Logging.Viewer.App.ViewModels
{
    public class ApplicationViewModel : Conductor<IScreen>, IDisposable
    {
        public ApplicationViewModel()
        {
            Title = "Xitaso Log Viewer";
            Version = "1.0.0";
            DisplayName = $"{Title} v{Version}";
            LogProviderList = new LogProviderListViewModel();
            LogEntries = new BindableCollection<LogEntryViewModel>();
            LogLevelFilter = new LogLevelFilterViewModel();

            LogFileProvider provider = new LogFileProvider();
            provider.FilePath = @"C:\Temp\logs\logfile.txt";
            provider.NewEntriesAvailable += On_FileListener_NewEntriesAvailable;
            provider.Start();
            LogProviderList.LogProviders.Add(provider);
        }

        public void Dispose()
        {
        }

        public string Title { get; set; }

        public string Version { get; set; }

        public LogProviderListViewModel LogProviderList { get; }

        public BindableCollection<LogEntryViewModel> LogEntries { get; }

        public LogLevelFilterViewModel LogLevelFilter { get; }

        private void On_FileListener_NewEntriesAvailable(ILogProvider logProvider)
        {
            try
            {
                var newEntries = logProvider.GetNewEntries();
                Execute.BeginOnUIThread(() => AddNewEntries(newEntries));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void AddNewEntries(List<LogEntry> newEntries)
        {
            var filteredEntries = LogLevelFilter.Apply(newEntries);
            filteredEntries.ForEach(e => LogEntries.Add(ApplyColorForLogLevel(new LogEntryViewModel(e))));
        }

        private LogEntryViewModel ApplyColorForLogLevel(LogEntryViewModel logEntry)
        {
            var filterSetting = LogLevelFilter.FilterSettings.FirstOrDefault(fs => fs.Name.Equals(logEntry.LogEntry.LogLevel));
            if (filterSetting == null)
            {
                logEntry.IsVisible = true;
                logEntry.BackgroundColorBrush = new SolidColorBrush(Colors.Transparent);
            }
            else
            {
                logEntry.IsVisible = filterSetting.IsActive;
                logEntry.BackgroundColorBrush = SafeColorConverter.ConvertToSolidBrush(filterSetting.ColorName);
            }
            return logEntry;
        }
    }
}
