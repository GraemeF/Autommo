namespace Autommo.Console
{
    #region Using Directives

    using System;
    using System.ServiceModel;
    using System.ServiceModel.Web;

    using Nancy.BootStrapper;
    using Nancy.Hosting.Wcf;

    #endregion

    public class Server : IServer
    {
        private readonly INancyBootStrapper _bootstrapper;

        private WebServiceHost _host;

        public Server(INancyBootStrapper bootStrapper)
        {
            _bootstrapper = bootStrapper;
        }

        public int Port { get; set; }

        #region IDisposable members

        public void Dispose()
        {
            if (_host != null)
                _host.Close();
        }

        #endregion

        #region IServer members

        public void Start()
        {
            _host = new WebServiceHost(new NancyWcfGenericService(_bootstrapper),
                                       new Uri("http://localhost:" + Port));

            _host.AddServiceEndpoint(typeof(NancyWcfGenericService), new WebHttpBinding(), string.Empty);
            _host.Open();
        }

        #endregion
    }
}