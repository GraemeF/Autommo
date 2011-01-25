namespace Autommo.Tests
{
    #region Using Directives

    using System.Net;

    using Nancy;

    using Should.Fluent;

    using Xunit;

    #endregion

    public class WorldModuleTests
    {
        private readonly WorldModule _test = new WorldModule();

        [Fact]
        public void GetStatus__ReturnsOKStatus()
        {
            _test.InvokeRouteForRequest(new Request("GET", "http://localhost/status", "http")).
                StatusCode.Should().Equal(HttpStatusCode.OK);
        }
    }
}