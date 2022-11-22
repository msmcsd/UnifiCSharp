using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using UnifiCommands.Logging;

namespace UnifiCommands.Commands.CodeCommands
{
    public class DownloadFileCommand
    {
        private readonly string _url;
        private readonly string _destination;
        private readonly string _cacheFolder;
        private readonly ILogger _logger;
        private readonly string _fileName;

        private int _progress;
        private readonly object _lock = new object();

        public DownloadFileCommand(string url, string destination, string cacheFolder, ILogger logger)
        {
            _url = url;
            _destination = destination;
            _cacheFolder = cacheFolder;
            _logger = logger;
            _fileName = Path.GetFileName(_url);
        }

        public async Task<string> DownloadFile()
        {
            _logger.LogInfo($"Downloading {_url} to {_destination}");
            using (var client = new WebClient())
            {
                _progress = 0;
                client.DownloadProgressChanged += DownloadProgressCallback;
                client.DownloadFileCompleted += DownloadFileComplete;

                try
                {
                    await client.DownloadFileTaskAsync(new Uri(_url), _destination);
                    return _destination;
                }
                catch (Exception)
                {
                    // Exception message will show in DownloadFileComplete()
                    if (File.Exists(_destination)) File.Delete(_destination);
                    return null;
                }
            }
        }

        private void DownloadProgressCallback(object sender, DownloadProgressChangedEventArgs e)
        {
            if (_progress != e.ProgressPercentage && e.ProgressPercentage % 10 == 0)
            {
                lock (_lock)
                {
                    if (_progress != 10 * (int)Math.Floor((decimal)e.ProgressPercentage / 10))
                    {
                        _logger.LogProgress($"     Downloading {_fileName}... {e.ProgressPercentage} % complete");
                        _progress = e.ProgressPercentage;
                    }
                }
            }
        }

        private void DownloadFileComplete(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                _logger.LogInfo($"File download cancelled for {_fileName}");
            }

            string msg = e.Error == null ? $"Finished downloading {_fileName}." : $"Downloading {_fileName} failed. {e.Error.Message}";
            if (e.Error == null)
                _logger.LogInfo(msg);
            else
                _logger.LogError(msg);

            if (e.Error != null)
            {
                if (File.Exists(_destination)) File.Delete(_destination);
                return;
            }

            if (!string.IsNullOrEmpty(_cacheFolder))
            {
                string cachedFile = Path.Combine(_cacheFolder, Path.GetFileName(_destination));
                if (!Directory.Exists(_cacheFolder)) Directory.CreateDirectory(_cacheFolder);

                File.Copy(_destination, cachedFile, true);
                _logger.LogInfo($"Copied to {cachedFile}");
            }
        }
    }
}
