using Newtonsoft.Json;
using UnifiCommands.CommandInfo;

namespace UnifiCommands.Report
{
    public class ReportItem
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "category")]
        public string Category { get; set; }

        [JsonProperty(PropertyName = "test")]
        public string Test { get; set; }

        [JsonProperty(PropertyName = "keyword")]
        public string Keyword { get; set; }

        [JsonProperty(PropertyName = "passed")]
        public bool Passed { get; set; }

        [JsonIgnore]
        public FullCommandInfo Command { get; set; }
    }
}
