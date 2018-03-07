using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xitaso.Logging.Viewer.App.Provider;
using Xitaso.Logging.Viewer.App.Utilities;

namespace Xitaso.Logging.Viewer.App.Model
{
    /// <summary>
    /// This is a LogProvider for LogFiles.
    /// </summary>
    public class LogFileProvider : ILogProvider
    {
        private LogFileListener _logFileListener;
        private List<LogEntry> _newEntries = new List<LogEntry>();
        private LogFileMessageConverter _messageConverter = new LogFileMessageConverter();
        private object _syncRoot = new object();

        #region construction and dispose
        public LogFileProvider()
        {
            _logFileListener = new LogFileListener();
            _logFileListener.NewEntries += On_LogFileListener_NewEntries;
        }

        public void Dispose()
        {
            _logFileListener?.Dispose();
        }
        #endregion

        public event Action<ILogProvider> NewEntriesAvailable;

        /// <summary>
        /// Path and file name of the log file that should be used as source.
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Starts watching to the file and raises NewEntriesAvailable events
        /// if new log messages arrive.
        /// </summary>
        public void Start()
        {
            var path = Path.GetDirectoryName(FilePath);
            var fileName = Path.GetFileName(FilePath);
            _logFileListener.Path = path;
            _logFileListener.FileName = fileName;
            _logFileListener.Start();
        }

        /// <summary>
        /// Stops watching the current log file.
        /// </summary>
        public void Stop()
        {
            _logFileListener.Stop();
        }

        /// <summary>
        /// Returns all LogEntries that are stored in the log file.
        /// </summary>
        /// <returns></returns>
        public List<LogEntry> GetAllEntries()
        {
            List<LogEntry> entries = new List<LogEntry>();
            var fileContentAsString = _logFileListener.Entries;
            foreach (var line in fileContentAsString)
            {
                var entry = _messageConverter.ConvertFromString(line);
                if (entry != null)
                    entries.Add(entry);
            }
            return entries;
        }

        /// <summary>
        /// Returns all new LogEntries that are arrived since the last call of GetNewEntries().
        /// </summary>
        /// <returns></returns>
        public List<LogEntry> GetNewEntries()
        {
            lock (_syncRoot)
            {
                var newEntries = _newEntries.ToList();
                _newEntries.Clear();
                return newEntries;
            }
        }


        private void On_LogFileListener_NewEntries(List<string> lines)
        {
            List<LogEntry> newEntries = new List<LogEntry>();
            foreach (var line in lines)
            {
                var entry = _messageConverter.ConvertFromString(line);
                if (entry != null)
                    newEntries.Add(entry);
            }
            AddNewEntriesAndRaiseEvent(newEntries);
        }

        private void AddNewEntriesAndRaiseEvent(List<LogEntry> newEntries)
        {
            lock (_syncRoot)
            {
                _newEntries.AddRange(newEntries);
                NewEntriesAvailable?.Invoke(this);
            }
        }

    }
}
