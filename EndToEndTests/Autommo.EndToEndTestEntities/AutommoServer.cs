﻿using System;
using System.Diagnostics;
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
        private static readonly Uri BaseUri = new Uri("http://God:8099");

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

        public void AddMob()
        {
            new HttpClient().Post(new Uri(BaseUri, "/mob").AbsoluteUri, null, HttpContentTypes.ApplicationJson);
        }
    }
}