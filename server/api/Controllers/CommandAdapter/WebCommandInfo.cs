using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Controllers.CommandAdapter;

/// <summary>
/// Mini version of CommandInfo used for Web only so less info is passed to React client.
/// </summary>
public class WebCommandInfo
{
    public string Command { get; set; }

    public string DisplayText { get; set; }

    public string ApiMethod { get; set; }
}