namespace Autommo.EndToEndTests
{
    #region Using Directives

    using Autommo.EndToEndTestEntities;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    #endregion

    public class ServerTestBase
    {
        private readonly AutommoServer _server = new AutommoServer();

        protected AutommoServer Server
        {
            get { return _server; }
        }

        [TestCleanup]
        public void Cleanup()
        {
            _server.Dispose();
        }
    }
}