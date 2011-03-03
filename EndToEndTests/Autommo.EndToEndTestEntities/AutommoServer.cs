namespace Autommo.EndToEndTestEntities
{
    #region Using Directives

    using System;
    using System.Diagnostics;
    using System.Net;

    using Autommo.Dto;

    using EasyHttp.Http;

    #endregion

    public class AutommoServer : IDisposable
    {
        private readonly Process _process;

#if DEBUG
        private const string Configuration = "Debug";
#else
        private const string Configuration = "Release";
#endif

        private const string ServerFolder = @"..\..\..\..\Autommo.Console\bin\" + Configuration;

        private const string ServerPath = ServerFolder + @"\Autommo.Console.exe";

        private static readonly Uri BaseUri = new Uri("http://127.0.0.1:8099");

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        ~AutommoServer()
        {
            Dispose(false);
        }

        public AutommoServer()
        {
            EnsureServerIsNotRunning();

            _process = Process.Start(ServerPath, "/port:8099");

            WaitForServerToStartResponding();
        }

        private void EnsureServerIsNotRunning()
        {
            Retry.Until(() => !PingServer(), "The server is already running.");
        }

        private void WaitForServerToStartResponding()
        {
            Retry.Until(() => _process.Responding &&
                              PingServer(), 
                        "The server did not respond in time.");
        }

        private bool PingServer()
        {
            try
            {
                WebRequest.Create(CreateUri("/status")).GetResponse();
                return true;
            }
            catch (WebException)
            {
                return false;
            }
        }

        private void Dispose(bool disposing)
        {
            Retry.Until(Close, "Could not stop server.");
        }

        private bool Close()
        {
            try
            {
                _process.CloseMainWindow();
            }
            catch (InvalidOperationException)
            {
            }

            return _process.HasExited;
        }

        public Mob AddMob()
        {
            var client = new HttpClient();
            client.Post(CreateUri("/mob"), new Mob(), Schema.ContentType);

            return client.Response.StaticBody<Mob>();
        }

        private static string CreateUri(string path)
        {
            return new Uri(BaseUri, path).AbsoluteUri;
        }

        public Neighbourhood GetNeighbourhood()
        {
            var client = new HttpClient();
            client.Get(CreateUri("/neighbourhood"));

            return client.Response.StaticBody<Neighbourhood>();
        }

        public void Move(Point point)
        {
            var client = new HttpClient();
            client.Post(CreateUri("/character/test/route"), point, Schema.ContentType);
        }

        public Character GetCharacter()
        {
            var client = new HttpClient();
            client.Get(CreateUri("/character/test"));

            return client.Response.StaticBody<Character>();
        }

        public Character AddCharacter(string id)
        {
            var client = new HttpClient();
            client.Put(CreateUri("/character/" + id), new Character(), Schema.ContentType);

            return client.Response.StaticBody<Character>();
        }
    }
}