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
using Xitaso.Logging.Viewer.App.Provider.Messages;
using Xitaso.Logging.Viewer.App.Utilities;

namespace Xitaso.Logging.Viewer.App.ViewModels
{
    public class ApplicationViewModel : Screen
    {
        private readonly IEventAggregator _eventAggregator;

        public ApplicationViewModel(
            IEventAggregator eventAggregator,
            LogProviderListViewModel logProviderListViewModel,
            LogLevelFilterViewModel logLevelFilterViewModel,
            LogEntryViewerContainerViewModel logEntryViewerContainer
            )
        {
            Title = "Xitaso Log Viewer";
            Version = "1.0.0";
            DisplayName = $"{Title} v{Version}";

            LogProviderListView = logProviderListViewModel;
            LogLevelFilterView = logLevelFilterViewModel;
            LogEntryViewerContainer = logEntryViewerContainer;
        }

        public string Title { get; set; }

        public string Version { get; set; }

        public LogProviderListViewModel LogProviderListView { get; }

        public LogLevelFilterViewModel LogLevelFilterView { get; }

        public LogEntryViewerContainerViewModel LogEntryViewerContainer { get; }
    }
}
