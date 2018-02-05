using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xitaso.Logging.Viewer.App.Model;
using Xitaso.Logging.Viewer.App.Utilities;

namespace Xitaso.Logging.Viewer.App.ViewModels
{
    public class ApplicationViewModel : Conductor<IScreen>
    {
        public ApplicationViewModel()
        {
            Title = "Xitaso Log Viewer";
            Version = "0.0.1";
            DisplayName = $"{Title} v{Version}";
            LogEntries = new BindableCollection<LogEntry>();

            LogFileProvider provider = new LogFileProvider();
            provider.FilePath = @"C:\Temp\logs\logfile.txt";
            provider.NewEntries += On_FileListener_NewEntries;
            provider.Start();
        }

        public string Title { get; set; }

        public string Version { get; set; }

        public BindableCollection<LogEntry> LogEntries { get; set; }

        private void On_FileListener_NewEntries(List<LogEntry> newEntries)
        {
            newEntries.ForEach(e => LogEntries.Add(e));
        }



    }
}
