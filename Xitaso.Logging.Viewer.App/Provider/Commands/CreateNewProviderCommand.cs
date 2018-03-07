using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xitaso.Logging.Viewer.App.Model;
using Xitaso.Logging.Viewer.App.Provider;
using Xitaso.Logging.Viewer.App.ViewModels;

namespace Xitaso.Logging.Viewer.App.Commands
{
    public class CreateNewProviderCommand : ICommand
    {
        private readonly ILogProviderService _logProviderService;

        public CreateNewProviderCommand(ILogProviderService logProviderService)
        {
            this._logProviderService = logProviderService;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _logProviderService.AddNewProvider();
        }
    }
}
