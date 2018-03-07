using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xitaso.Logging.Viewer.App.Commands;
using Xitaso.Logging.Viewer.App.Model;
using Xitaso.Logging.Viewer.App.Provider;
using Xitaso.Logging.Viewer.App.Provider.Commands;
using Xitaso.Logging.Viewer.App.Provider.Messages;

namespace Xitaso.Logging.Viewer.App.ViewModels
{
    public class LogProviderListViewModel : Screen, IDisposable, IHandle<LogProviderSelectionChangedMessage>
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly ILogProviderService _logProviderService;
        private ILogProvider _selectedLogProvider;

        public LogProviderListViewModel(IEventAggregator eventAggregator, ILogProviderService logProviderService)
        {
            this._eventAggregator = eventAggregator;
            this._logProviderService = logProviderService;
            _eventAggregator.Subscribe(this);
            LogProviders = _logProviderService.LogProviders;
            CreateNewLogProviderCommand = new CreateNewProviderCommand(_logProviderService);
        }

        public void Dispose()
        {
            LogProviders.ToList().ForEach(lp => lp.Dispose());
        }

        public BindableCollection<ILogProvider> LogProviders { get; }

        public ICommand CreateNewLogProviderCommand { get; }

        public ILogProvider SelectedLogProvider
        {
            get => _selectedLogProvider;
            set
            {
                if (_selectedLogProvider == value) return;
                _selectedLogProvider = value;
                _logProviderService.SelectProvider(value);
                this.NotifyOfPropertyChange(nameof(SelectedLogProvider));
            }
        }

        public void Handle(LogProviderSelectionChangedMessage message)
        {
            this.SelectedLogProvider = message.SelectedLogProvider;
        }
    }
}
