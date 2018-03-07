using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xitaso.Logging.Viewer.App.Provider.Messages;

namespace Xitaso.Logging.Viewer.App.ViewModels
{
    public class LogEntryViewerContainerViewModel : Conductor<LogEntryViewerViewModel>.Collection.OneActive, IHandle<LogProviderSelectionChangedMessage>
    {
        private readonly IEventAggregator _eventAggregator;

        public LogEntryViewerContainerViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
        }

        public void Handle(LogProviderSelectionChangedMessage message)
        {
            var logProviderToSelect = this.Items.SingleOrDefault(lp => lp != null && lp.LogProvider == message.SelectedLogProvider);
            if (logProviderToSelect == null)
            {
                logProviderToSelect = new LogEntryViewerViewModel(message.SelectedLogProvider);
            }
            this.ActivateItem(logProviderToSelect);
        }
    }
}
