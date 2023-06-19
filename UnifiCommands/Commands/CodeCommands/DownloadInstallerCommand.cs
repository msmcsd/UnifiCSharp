using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnifiCommands.CommandInfo;
using UnifiCommands.Logging;
using static UnifiCommands.Commands.CodeCommands.DownloadInstallerCommand;

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
            var successfulBuilds = await GetSuccessfulBuilds(_job, Logger);
            if (successfulBuilds == null) return null;

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

            return null;
        }

        //private async Task<Build> GetLastSuccessfulWindowsBuildNumber()
        //{
        //    string url = string.Format(Variables.AllBuildsInfoUrl, _job) + "{0,10}";
        //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        //    request.ContentType = "application/json";
        //    request.Method = "GET";

        //    try
        //    {
        //        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        //        if (response.StatusCode == HttpStatusCode.OK)
        //        {
        //            using (var reader = new StreamReader(response.GetResponseStream()))
        //            {
        //                string json = await reader.ReadToEndAsync();
        //                var jsonSerializerSettings = new JsonSerializerSettings();
        //                jsonSerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
        //                var allBuilds = JsonConvert.DeserializeObject<AllBuildsInfo>(json, jsonSerializerSettings);

        //                var successfulBuilds = allBuilds.Builds
        //                    .Where(b => b.Result.Equals("SUCCESS", StringComparison.InvariantCultureIgnoreCase))
        //                    .OrderByDescending(b => b.BuildNumber).ToList();


        //                foreach (var b in successfulBuilds)
        //                {
        //                    foreach (var action in b.Actions)
        //                    {
        //                        var windowsPlatform = action.Parameters?.FirstOrDefault(p =>
        //                            p.Name.Equals("PlatformChoice", StringComparison.InvariantCultureIgnoreCase) &&
        //                            p.Value.IndexOf("Windows", StringComparison.InvariantCultureIgnoreCase) >= 0);

        //                        if (windowsPlatform != null)
        //                        {
        //                            Logger.LogInfo($"Last successful Windows build number is {b.BuildNumber}");
        //                            return b;
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Logger.LogError(e.Message);
        //    }

        //    return null;
        //}

        public async static Task<List<Build>> GetSuccessfulBuilds(string url, ILogger logger, int batch = 0)
        {
            if (batch < 0) batch = 0;
            url = string.Format(Variables.AllBuildsInfoUrl, url) + "{" + batch + "," + batch + 10 + "}";
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
                            .Where(b => (b.Result.Equals("SUCCESS", StringComparison.InvariantCultureIgnoreCase) || b.Result.Equals("UNSTABLE", StringComparison.InvariantCultureIgnoreCase))
                                        && !b.building)
                            .OrderByDescending(b => b.BuildNumber).ToList();

                        return successfulBuilds;
                    }
                }
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
            }

            return null;
        }

        public async static Task<string> GetBuildNumberByVersion(string url, string version, ILogger logger)
        {
            for (int i = 0; i < 5; i++)
            {
                var builds = await GetSuccessfulBuilds(url, logger, i);
                if (builds == null) return null;

                var build = builds.FirstOrDefault(b => b.DisplayName.Contains(version));
                if (build != null)
                {
                    return build.BuildNumber.ToString();
                }
            }
            logger.LogError($"Build version {version} not found.");
            return null;
        }

        public async static Task<string> GetVersionByBuildNumber(string url, int buildNumber, ILogger logger)
        {
            for (int i = 0; i < 5; i++)
            { 
                var builds = await GetSuccessfulBuilds(url, logger, i);
                if (builds == null) return null;

                var build = builds.FirstOrDefault(b => b.BuildNumber == buildNumber);
                if (build != null)
                {
                    return GetBuildVersionFromDisplayName(build.DisplayName);
                }
            }

            logger.LogError($"Build number {buildNumber} not found.");
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
                    return null;
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
                //int i = build.DisplayName.IndexOf("[", StringComparison.InvariantCultureIgnoreCase);
                //if (i >= 0)
                //{
                //    version = build.DisplayName.Substring(i + 1, build.DisplayName.Length - i - 2);
                //}
                version = GetBuildVersionFromDisplayName(build.DisplayName);
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
                return cacheInstaller;
            }

            //
            // Download the installer based on the build no.
            //
            _destination = $"{Variables.InstallerDownloadFolder}\\{_installerFileName}";
            string jenkinsUrl = _job.ToLower().Contains("dtd") || _job.ToLower().Contains("esse") ? Variables.DellJenkinsUrl : Variables.ProtectJenkinsUrl;
            string url = string.Format(jenkinsUrl, _job, buildNo, _installerFileName);

            var cmd = new DownloadFileCommand(url, _destination, _cacheFolder, Logger);
            await cmd.DownloadFile();

            return cacheInstaller;
        }

        // Display Name may look something like this: #1133:[3.1.9200.15138/16838] task/branch123. Only first version (Windows) is needed.
        private static string GetBuildVersionFromDisplayName(string displayName)
        {
            string version = "N/A";
            int i = displayName.IndexOf("[", StringComparison.InvariantCultureIgnoreCase);
            if (i >= 0)
            {
                int j = displayName.IndexOf("]");
                if (j > 0)
                {
                    version = displayName.Substring(i + 1, j - i - 1);
                    if (version.IndexOf("/") > 0)
                    {
                        version = version.Split(new char[] {'/'})[0];
                    }
                }
            }
            
            return version;
        }

        public static string GetInstallerNameByType(InstallerType installerType, string jobUrl)
        {
            switch (installerType)
            {
                case InstallerType.Msi: return GetMsiInstallerName(jobUrl);
                case InstallerType.CyUpgrade: return GetCyUpgradeName(jobUrl);
                default: return GetBootstrapperName(jobUrl);
            }
        }

        public static string GetMsiInstallerName(string jobUrl)
        {
            if (jobUrl.ToLower().Contains("/dtd/")) return Variables.DtdInstallerName;
            if (jobUrl.ToLower().Contains("/esse/")) return Variables.EsseInstallerName;

            return Variables.ProtectMsiNameByVmArch;
        }

        public static string GetCyUpgradeName(string jobUrl)
        {
            if (jobUrl.ToLower().Contains("esse")) return Variables.EsseUpgradeInstallerName;
            if (!jobUrl.ToLower().Contains("dtd")) return Variables.ProtectUpgradeInstallerName;

            return "";
        }

        public static string GetBootstrapperName(string jobUrl)
        {
            return Variables.ProtectBootstrapperName;
        }

        /// <summary>
        /// Makes a clone of "command" which contains download urls and sets the command to a DownloadInstaller command.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="installerType"></param>
        /// <returns></returns>
        public static FullCommandInfo SetUpCommand(FullCommandInfo command, InstallerType installerType)
        {
            FullCommandInfo clone = (FullCommandInfo)command.Clone();
            clone.Command = "DownloadInstaller";

            string installerFileName = GetInstallerNameByType(installerType, command.Command);

            // Command: build job
            // Arguments: Version of installer to download
            clone.Arguments = $"{command.Command}, {command.Arguments}, {installerFileName}, {command.DisplayText}";
            clone.Type = CommandType.Code;

            return clone;
        }
    }
}
