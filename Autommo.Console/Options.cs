#region Using Directives

using CommandLine;

#endregion

public class Options
{
    [Argument(ArgumentType.AtMostOnce, HelpText = "Port number to listen on.")]
    public int port = 8080;
}