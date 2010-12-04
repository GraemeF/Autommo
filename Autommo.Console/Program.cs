using CommandLine;

namespace Autommo.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var options = new Options();
            if (Parser.ParseArgumentsWithUsage(args, options))
            {
            }
        }

        #region Nested type: Options

        private class Options
        {
            [Argument(ArgumentType.Required, HelpText = "Port number to listen on.")]
            public uint port = 8080;
        }

        #endregion
    }
}