using System;
using System.ServiceModel;
using System.ServiceModel.Web;
using CommandLine;
using Nancy.Hosting.Wcf;

namespace Autommo.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var options = new Options();
            if (!Parser.ParseArgumentsWithUsage(args, options))
                return;

            using (var host = new WebServiceHost(new NancyWcfGenericService(typeof (MobsModule).Assembly),
                                                 new Uri("http://localhost:" + options.port)))
            {
                host.AddServiceEndpoint(typeof (NancyWcfGenericService), new WebHttpBinding(), "");
                host.Open();

                System.Console.ReadLine();
            }
        }

        #region Nested type: Options

        private class Options
        {
            [Argument(ArgumentType.AtMostOnce, HelpText = "Port number to listen on.")]
            public int port = 8080;
        }

        #endregion
    }
}