using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Xitaso.Logging.Viewer.App.Model;

namespace Xitaso.Logging.Viewer.App.ViewModels
{
    public class LogEntryViewModel : PropertyChangedBase
    {
        private bool _isVisible;
        private SolidColorBrush _backgroundColor;

        public LogEntryViewModel(LogEntry entry)
        {
            LogEntry = entry;
        }

        public LogEntry LogEntry { get; }

        public bool IsVisible
        {
            get => _isVisible;
            set
            {
                _isVisible = value;
                NotifyOfPropertyChange(nameof(IsVisible));
            }
        }

        public SolidColorBrush BackgroundColorBrush
        {
            get => _backgroundColor;
            set
            {
                _backgroundColor = value;
                NotifyOfPropertyChange(nameof(BackgroundColorBrush));
            }
        }
    }
}
