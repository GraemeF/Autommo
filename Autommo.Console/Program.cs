namespace Autommo.Console
{
    #region Using Directives

    using System;
    using System.IO;
    using System.Reflection;

    using CommandLine;

    #endregion

    internal class Program
    {
        private static void Main(string[] args)
        {
            var options = new Options();
            if (!Parser.ParseArgumentsWithUsage(args, options))
                return;

            using (StartServer(options))
                Console.ReadLine();
        }

        private static IServer StartServer(Options options)
        {
            IServer server = new Server(new AutommoBootstrapper());

            server.Port = options.port;
            server.Start();

            return server;
        }
    }
}