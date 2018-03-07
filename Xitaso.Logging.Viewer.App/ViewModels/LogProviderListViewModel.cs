using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xitaso.Logging.Viewer.App.Model;

namespace Xitaso.Logging.Viewer.App.ViewModels
{
    public class LogProviderListViewModel : Screen, IDisposable
    {
        public LogProviderListViewModel()
        {
            LogProviders = new BindableCollection<ILogProvider>();
        }

        public void Dispose()
        {
            LogProviders.ToList().ForEach(lp => lp.Dispose());
        }

        public BindableCollection<ILogProvider> LogProviders { get; }

    }
}
