using System;
using System.ComponentModel.Composition;
using System.ServiceModel;
using System.ServiceModel.Web;
using Nancy;
using Nancy.Hosting.Wcf;

namespace Autommo.Console
{
    [Export(typeof (IServer))]
    public class Server : IDisposable, IServer
    {
        private readonly INancyModuleLocator _moduleLocator;
        private WebServiceHost _host;

        [ImportingConstructor]
        public Server(INancyModuleLocator moduleLocator)
        {
            _moduleLocator = moduleLocator;
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (_host != null)
                _host.Close();
        }

        #endregion

        #region IServer Members

        public int Port { get; set; }

        public void Start()
        {
            _host = new WebServiceHost(new NancyWcfGenericService(_moduleLocator),
                                       new Uri("http://localhost:" + Port));

            _host.AddServiceEndpoint(typeof (NancyWcfGenericService), new WebHttpBinding(), "");
            _host.Open();
        }

        #endregion
    }
}