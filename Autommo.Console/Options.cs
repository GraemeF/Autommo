using CommandLine;

public class Options
{
    [Argument(ArgumentType.AtMostOnce, HelpText = "Port number to listen on.")]
    public int port = 8080;
}