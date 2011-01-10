using System;
using System.Diagnostics;
using System.Net;
using System.Threading;
using Autommo.Dto;
using EasyHttp.Http;

namespace Autommo.EndToEndTestEntities
{
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
            _process = Process.Start(ServerPath, "/port:8099");

            WaitForServerToStartResponding();
        }

        private void WaitForServerToStartResponding()
        {
            for (int remainingTries = 50; remainingTries >= 0; remainingTries--)
            {
                try
                {
                    PingServer();
                    break;
                }
                catch (WebException)
                {
                    if (remainingTries == 0)
                        throw;

                    Thread.Sleep(100);
                }
            }
        }

        private void PingServer()
        {
            new HttpClient().Get(new Uri(BaseUri, "status").AbsoluteUri);
        }

        private void Dispose(bool disposing)
        {
            try
            {
                _process.CloseMainWindow();
            }
            catch (InvalidOperationException)
            {
                if (!_process.HasExited)
                    throw;
            }
        }

        public Mob AddMob()
        {
            var client = new HttpClient();
            client.Post(new Uri(BaseUri, "/mob").AbsoluteUri, new Mob(), Schema.ContentType);

            return client.Response.StaticBody<Mob>();
        }

        public Neighbourhood GetNeighbourhood()
        {
            var client = new HttpClient();
            client.Get(new Uri(BaseUri, "/neighbourhood").AbsoluteUri);

            return client.Response.StaticBody<Neighbourhood>();
        }

        public void Move(WorldPoint worldPoint)
        {
            throw new NotImplementedException();
        }
    }
}