using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xitaso.Logging.Viewer.App.Model
{
    /// <summary>
    /// Interface for LogProvider.
    /// Every provider of LogEntry instances has to implement this interface.
    /// </summary>
    public interface ILogProvider : IDisposable
    {

        /// <summary>
        /// Starts querying the source.
        /// </summary>
        void Start();

        /// <summary>
        /// Stops querying the source.
        /// </summary>
        void Stop();

        /// <summary>
        /// Returns a list of all entries found within the source.
        /// </summary>
        /// <returns></returns>
        List<LogEntry> GetAllEntries();

        /// <summary>
        /// Returns the list of new entries that are never fetched.
        /// After the call, the list will be cleared.
        /// </summary>
        /// <returns></returns>
        List<LogEntry> GetNewEntries();

        /// <summary>
        /// This event will be fired if a new entry arrives.
        /// </summary>
        event Action<ILogProvider> NewEntriesAvailable;
    }
}
