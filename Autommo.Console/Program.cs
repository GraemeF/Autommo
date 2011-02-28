namespace Autommo.Console
{
    #region Using Directives

    using System;

    using CommandLine;

    #endregion

    internal class Program
    {
        private static void Main(string[] args)
        {
            var options = new Options();
            if (!Parser.ParseArgumentsWithUsage(args, options))
                return;

            using (IServer server = StartServer(options))
            {
                Console.WriteLine("Listening on port " + server.Port);
                Console.ReadLine();
            }
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