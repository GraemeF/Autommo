using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.IO;
using System.Reflection;
using CommandLine;

namespace Autommo.Console
{
    internal class Program
    {
        private static ComposablePartCatalog GetCatalog()
        {
            DirectoryCatalog directoryCatalog = GetDirectoryCatalog();
            var assemblyCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());

            return new AggregateCatalog(directoryCatalog, assemblyCatalog);
        }

        private static DirectoryCatalog GetDirectoryCatalog()
        {
            return new DirectoryCatalog(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }

        private static void Main(string[] args)
        {
            var options = new Options();
            if (!Parser.ParseArgumentsWithUsage(args, options))
                return;

            using (StartServer(options))
                System.Console.ReadLine();
        }

        private static IServer StartServer(Options options)
        {
            IServer server = ComposeServer();

            server.Port = options.port;
            server.Start();

            return server;
        }

        private static IServer ComposeServer()
        {
            return new CompositionContainer(GetCatalog()).GetExportedValue<IServer>();
        }
    }
}