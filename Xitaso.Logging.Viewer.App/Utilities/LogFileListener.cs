using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xitaso.Logging.Viewer.App.Utilities
{
    public class LogFileListener : IDisposable
    {
        private FileSystemWatcher _fileWatcher;
        private long _lastPosition = 0;
        private readonly List<string> _lines;

        public LogFileListener()
        {
            _lines = new List<string>();
            _fileWatcher = new FileSystemWatcher();
            _fileWatcher.EnableRaisingEvents = false;
            _fileWatcher.Changed += On_FileWatcher_Changed;
        }

        public void Dispose()
        {
            _fileWatcher?.Dispose();
            _fileWatcher = null;
        }

        public event Action<List<string>> NewEntries;

        public string Path { get; set; }

        public string FileName { get; set; }

        public void Start()
        {
            _fileWatcher.Path = Path;
            _fileWatcher.Filter = FileName;
            ReadContent();
            _fileWatcher.EnableRaisingEvents = true;
        }

        public void Stop()
        {
            _fileWatcher.EnableRaisingEvents = false;
        }

        public List<string> Entries => _lines;

        private void On_FileWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            try
            {
                ReadContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ReadContent()
        {
            string content;
            string filePath = System.IO.Path.Combine(Path, FileName);
            if (File.Exists(filePath) == false) return;

            using (FileStream stream =
                new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                if (stream.Length <= _lastPosition)
                    _lastPosition = 0;
                stream.Position = _lastPosition;
                
                using (StreamReader reader = new StreamReader(stream))
                {
                    content = reader.ReadToEnd();
                    _lastPosition = stream.Position;
                }
            }
            var lines = content.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            _lines.AddRange(lines);

            NewEntries?.Invoke(lines.ToList());
        }

    }
}
