using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xitaso.Logging.Viewer.App.Utilities;

namespace Xitaso.Logging.Viewer.App.Model
{
    public class LogFileProvider : ILogProvider
    {
        private LogFileListener _logFileListener;

        public LogFileProvider()
        {
            _logFileListener = new LogFileListener();
            _logFileListener.NewEntries += On_LogFileListener_NewEntries;
        }

        public void Dispose()
        {
            _logFileListener?.Dispose();
        }

        public event Action<List<LogEntry>> NewEntries;

        public string FilePath { get; set; }

        public void Start()
        {
            var path = Path.GetDirectoryName(FilePath);
            var fileName = Path.GetFileName(FilePath);
            _logFileListener.Path = path;
            _logFileListener.FileName = fileName;
            _logFileListener.Start();
        }

        public void Stop()
        {
            _logFileListener.Stop();
        }

        public void Pause()
        {
            _logFileListener.Stop();
        }

        public List<LogEntry> GetAllEntries()
        {
            List<LogEntry> entries = new List<LogEntry>();
            var content = _logFileListener.Entries;
            foreach (var line in content)
            {
                var entry = LogEntry.Parse(line);
                if (entry != null)
                    entries.Add(entry);
            }
            return entries;
        }

        private void On_LogFileListener_NewEntries(List<string> lines)
        {
            List<LogEntry> entries = new List<LogEntry>();
            foreach (var line in lines)
            {
                var entry = LogEntry.Parse(line);
                if (entry != null)
                    entries.Add(entry);
            }
            NewEntries?.Invoke(entries);
        }


    }
}
