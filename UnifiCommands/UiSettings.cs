using static UnifiCommands.Commands.CodeCommands.DownloadInstallerCommand;
using UnifiCommands;
using Newtonsoft.Json;

namespace UnifiCommands
{
    /// <summary>
    /// Corresponds to the UI settings.
    /// </summary>
    public class UiSettings
    {
        [JsonProperty("getconfig")]
        public Config Config { get; set; }

        [JsonProperty("compilemode")]
        public string CompileMode { get; set; }

        [JsonProperty("cylancedesktopfolder")]
        public string InstallFolder { get; set; }

        [JsonProperty("buildJobSourceInfo")]
        public BuildJobSourceInfo BuildJobSourceInfo { get; set; }

        [JsonProperty("buildJobTypeInfo")]
        public BuildJobTypeInfo BuildJobTypeInfo { get; set; }

        [JsonProperty("installerType")]
        public InstallerType InstallerType { get; set; }
    }

    public enum Config
    {
        r01,
        r02,
        qa2
    }

    public enum BuildJobSourceType
    {
        Me,
        BC,
        Release
    }

    public enum BuildType
    {
        Latest,
        Version,
        BuildNumber
    }
}

    /// <summary>
    /// Corresponds to the Jenkins area in the Download section
    /// </summary>
    public class BuildJobSourceInfo
    {
        [JsonProperty("buildJobSourceType")]
        public BuildJobSourceType BuildJobSourceType { get; set; }

        [JsonProperty("buildJobUrl")]
        public string BuildJobUrl { get; set; }

        [JsonProperty("releaseVersion")]
        public string ReleaseVersion { get; set; }
    }

    /// <summary>
    /// Corresponds to the Build area in the Download section
    /// </summary>
    public class BuildJobTypeInfo
    {
        [JsonProperty("buildType")]
        public BuildType BuildType { get; set; }

        [JsonProperty("buildVersion")]
        public string BuildVersion { get; set; }

        [JsonProperty("buildNumber")]
        public string BuildNumber { get; set; }
    }

