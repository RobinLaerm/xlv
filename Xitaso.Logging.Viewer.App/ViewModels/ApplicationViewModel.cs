using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xitaso.Logging.Viewer.App.ViewModels
{
    public class ApplicationViewModel : Conductor<IScreen>
    {
        public ApplicationViewModel()
        {
            Title = "Xitaso Log Viewer";
            Version = "0.0.1";
            DisplayName = $"{Title} v{Version}";
        }

        public string Title { get; set; }

        public string Version { get; set; }
    }
}
