namespace Autommo.Tests
{
    #region Using Directives

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Nancy;

    using Should.Fluent;

    #endregion

    [TestClass]
    public class WorldModuleTests
    {
        private readonly WorldModule _test = new WorldModule();

        [TestMethod]
        public void GetStatus__ReturnsOKStatus()
        {
            _test.InvokeRouteForRequest(new Request("GET", "http://localhost/status", "http"), "/status").
                StatusCode.Should().Equal(HttpStatusCode.OK);
        }
    }
}