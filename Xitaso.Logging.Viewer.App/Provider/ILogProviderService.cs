using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xitaso.Logging.Viewer.App.Model;

namespace Xitaso.Logging.Viewer.App.Provider
{
    public interface ILogProviderService
    {
        BindableCollection<ILogProvider> LogProviders { get; }

        void AddNewProvider();

        void SelectProvider(ILogProvider logProvider);
    }
}
