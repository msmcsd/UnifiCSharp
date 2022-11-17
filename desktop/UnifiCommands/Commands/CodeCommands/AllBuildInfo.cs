﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace UnifiCommands.Commands.CodeCommands
{
    internal class AllBuildsInfo
    {
        public List<Build> Builds { get; set; }
    }

    internal class Build
    {
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("number")]
        public int BuildNumber { get; set; }

        [JsonProperty("result")]
        public string Result { get; set; }

        [JsonProperty("actions")]
        public List<Action> Actions { get; set; }
    }

    internal class Parameter
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; } = "";
    }

    internal class Action
    {
        [JsonProperty("parameters")]
        public List<Parameter> Parameters { get; set; }
    }
}