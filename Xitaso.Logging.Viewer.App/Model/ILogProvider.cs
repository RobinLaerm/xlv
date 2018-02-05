using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xitaso.Logging.Viewer.App.Model
{
    public interface ILogProvider : IDisposable
    {
        void Start();
        void Stop();
        void Pause();

        List<LogEntry> GetAllEntries();

        event Action<List<LogEntry>> NewEntries;
    }
}
