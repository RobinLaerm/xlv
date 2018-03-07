using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xitaso.Logging.Viewer.App.Model;

namespace Xitaso.Logging.Viewer.App.ViewModels
{
    public class LogEntryViewerViewModel : Screen
    {
        public LogEntryViewerViewModel(ILogProvider logProvider)
        {
            LogEntries = new BindableCollection<LogEntryViewModel>();
            LogProvider = logProvider;
            LogProvider.NewEntriesAvailable += On_LogProvider_NewEntriesAvailable;
            LogProvider.Start();
        }

        public ILogProvider LogProvider { get; }

        public BindableCollection<LogEntryViewModel> LogEntries { get; }


        private void On_LogProvider_NewEntriesAvailable(ILogProvider logProvider)
        {
            Execute.BeginOnUIThread(UpdateListOfLogEntries);
        }

        private void UpdateListOfLogEntries()
        {
            var newEntries = LogProvider.GetNewEntries();
            var viewModels = newEntries.Select(e => new LogEntryViewModel(e));
            LogEntries.AddRange(viewModels);
        }
    }
}
