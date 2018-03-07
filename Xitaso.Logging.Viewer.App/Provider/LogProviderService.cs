using Caliburn.Micro;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xitaso.Logging.Viewer.App.Model;
using Xitaso.Logging.Viewer.App.Provider.Messages;

namespace Xitaso.Logging.Viewer.App.Provider
{
    public class LogProviderService : ILogProviderService
    {
        private readonly IEventAggregator _eventAggregator;

        public LogProviderService(IEventAggregator eventAggregator)
        {
            this._eventAggregator = eventAggregator;
            LogProviders = new BindableCollection<ILogProvider>();
        }

        public BindableCollection<ILogProvider> LogProviders { get; }

        public ILogProvider SelectedLogProvider { get; private set; }

        public void AddNewProvider()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog();
            var fileName = dialog.FileName;
            LogFileProvider provider = new LogFileProvider();
            provider.FilePath = fileName;
            LogProviders.Add(provider);
            SelectProvider(provider);
        }

        public void SelectProvider(ILogProvider logProvider)
        {
            SelectedLogProvider = logProvider;
            _eventAggregator.PublishOnCurrentThread(new LogProviderSelectionChangedMessage(SelectedLogProvider));
        }
    }
}
