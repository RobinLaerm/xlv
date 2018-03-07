using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xitaso.Logging.Viewer.App.Model;
using Xitaso.Logging.Viewer.App.Provider.Messages;

namespace Xitaso.Logging.Viewer.App.Provider.Commands
{
    public class SelectProviderCommand : ICommand
    {
        private readonly ILogProviderService _logProviderService;

        public SelectProviderCommand(ILogProviderService logProviderService)
        {
            this._logProviderService = logProviderService;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _logProviderService.LogProviders.Count > 0;
        }

        public void Execute(object parameter)
        {
            var logProvider = parameter as ILogProvider;
            _logProviderService.SelectProvider(logProvider);
        }
    }
}
