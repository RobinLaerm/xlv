using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xitaso.Logging.Viewer.App.Model;

namespace Xitaso.Logging.Viewer.App.Provider.Messages
{
    public class LogProviderSelectionChangedMessage
    {
        public LogProviderSelectionChangedMessage(ILogProvider selectedLogProvider)
        {
            SelectedLogProvider = selectedLogProvider;
        }

        public ILogProvider SelectedLogProvider { get; }
    }
}
