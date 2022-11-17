using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnifiCommands.Logging;

namespace UnifiCommands.Commands.CodeCommands
{
    /// <summary>
    /// Downloads an installer from Jenkins. Copy from cache folder first if it already exists.
    /// </summary>
    public class DownloadInstallerCommand : Command
    {
        private readonly string _job;
        private string _jenkinsBuildNumber;
        private readonly string _buildDescription;
        private readonly string _installerFileName;
        private string _cacheFolder;
        private string _destination;

        public DownloadInstallerCommand(string job, string jenkinsBuildNumber, string installerFileName, string buildDescription, ILogger logger) : base(logger)
        {
            if (!jenkinsBuildNumber.Equals(Variables.LastSuccessfulBuild, StringComparison.InvariantCultureIgnoreCase) &&
                !int.TryParse(jenkinsBuildNumber, out int _))
            {
                throw new ArgumentOutOfRangeException(@"Invalid build number.");
            }

            _job = job;
            _jenkinsBuildNumber = jenkinsBuildNumber;
            _installerFileName = installerFileName;
            _buildDescription = buildDescription;
        }

        public override void LogParameters()
        {
            LogCommand($"File: {_installerFileName}", $"Version: {_buildDescription}");
        }

        /// <summary>
        /// Gets the info, using REST API, of the last 10 builds and finds out the last successful Windows build.
        /// Sample JSON returned:
        /// {
        ///     "builds": [
        ///         "actions": [
        ///             "parameters" : [
        ///                 "name": "PlatformChoice",
        ///                 "value": "windows"
        ///             ],
        ///         ],
        ///         "displayName" : "#2308:[3.1.9700.33119]",
        ///         "number" : 2308,
        ///         "result" : "SUCCESS"
        ///     ]
        /// }
        /// </summary>
        /// <returns></returns>
        private async Task<Build> GetLastSuccessfulWindowsBuildNumber()
        {
            string url = string.Format(Variables.AllBuildsInfoUrl, _job) + "{0,10}";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Method = "GET";

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        string json = await reader.ReadToEndAsync();
                        var jsonSerializerSettings = new JsonSerializerSettings();
                        jsonSerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
                        var allBuilds = JsonConvert.DeserializeObject<AllBuildsInfo>(json, jsonSerializerSettings);

                        var successfulBuilds = allBuilds.Builds
                            .Where(b => b.Result.Equals("SUCCESS", StringComparison.InvariantCultureIgnoreCase))
                            .OrderByDescending(b => b.BuildNumber).ToList();


                        foreach (var b in successfulBuilds)
                        {
                            foreach (var action in b.Actions)
                            {
                                var windowsPlatform = action.Parameters?.FirstOrDefault(p =>
                                    p.Name.Equals("PlatformChoice", StringComparison.InvariantCultureIgnoreCase) &&
                                    p.Value.IndexOf("Windows", StringComparison.InvariantCultureIgnoreCase) >= 0);

                                if (windowsPlatform != null)
                                {
                                    Logger.LogInfo($"Last successful Windows build number is {b.BuildNumber}");
                                    return b;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
            }

            return null;
        }

        protected override async Task<string> ExecuteCommand()
        {
            //
            // Identify the latest build number if "lastSuccessfulBuild" is the build number.
            //
            bool selectedItemIsVersion = Utils.IsVersion(_buildDescription);
            int buildNo;
            Build build = null;
            string version = "";

            if (!selectedItemIsVersion)
            {
                build = await GetLastSuccessfulWindowsBuildNumber();
                if (build == null)
                {
                    Logger.LogError("Unable to find last successful build");
                    return "";
                }

                buildNo = build.BuildNumber;
            }
            else
            {
                int.TryParse(_jenkinsBuildNumber, out buildNo);
                version = _buildDescription;
            }

            if (build != null)
            {
                int i = build.DisplayName.IndexOf("[", StringComparison.InvariantCultureIgnoreCase);
                if (i >= 0)
                {
                    version = build.DisplayName.Substring(i + 1, build.DisplayName.Length - i - 2);
                }
            }

            Logger.LogInfo($"Version to download {version}");

            //
            // Copy the installer from cache if it already exists.
            //
            string cacheInstaller = Path.Combine(Variables.InstallersFolder, $@"{version}\{_installerFileName}");
            _cacheFolder = Path.GetDirectoryName(cacheInstaller);
            if (File.Exists(cacheInstaller))
            {
                File.Copy(cacheInstaller, Path.Combine(Variables.InstallerDownloadFolder, _installerFileName), true);
                Logger.LogInfo($"Copied from {cacheInstaller}");
                return "";
            }

            //
            // Download the installer based on the build no.
            //
            _destination = $"{Variables.InstallerDownloadFolder}\\{_installerFileName}";
            string jenkinsUrl = _job.ToLower().Contains("dtd") || _job.ToLower().Contains("esse") ? Variables.DellJenkinsUrl : Variables.ProtectJenkinsUrl;
            string url = string.Format(jenkinsUrl, _job, buildNo, _installerFileName);

            var cmd = new DownloadFileCommand(url, _destination, _cacheFolder, Logger);
            await cmd.DownloadFile();

            return "";
        }
    }

    internal enum InstallerType
    {
        Msi,
        Bootstrapper,
        CyUpgrade
    }
}
