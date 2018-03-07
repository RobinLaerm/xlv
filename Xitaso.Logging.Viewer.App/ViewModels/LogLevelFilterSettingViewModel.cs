using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Xitaso.Logging.Viewer.App.Converter;
using Xitaso.Logging.Viewer.App.Model;

namespace Xitaso.Logging.Viewer.App.ViewModels
{
    public class LogLevelFilterSettingViewModel : PropertyChangedBase
    {
        private readonly LogLevelFilterSetting _filterSetting;

        public LogLevelFilterSettingViewModel(LogLevelFilterSetting filterSetting)
        {
            this._filterSetting = filterSetting;
        }

        public bool IsActive
        {
            get => _filterSetting.IsActive;
            set => _filterSetting.IsActive = value;
        }

        public string Name
        {
            get => _filterSetting.Name;
            set => _filterSetting.Name = value;
        }

        public string ColorName
        {
            get => _filterSetting.ColorName;
            set => _filterSetting.ColorName = value;
        }

        public Brush BackgroundColorBrush
        {
            get => SafeColorConverter.ConvertToSolidBrush(ColorName);
        }
    }
}
