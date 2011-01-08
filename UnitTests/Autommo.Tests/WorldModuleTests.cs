namespace Autommo.Tests
{
    using System.Net;

    using Nancy;
    using Nancy.Routing;

    using Should.Fluent;

    using Xunit;

    public class WorldModuleTests
    {
        private readonly WorldModule _test = new WorldModule();

        [Fact]
        public void GetStatus__ReturnsOKStatus()
        {
            IRoute route = _test.GetRouteForRequest(new Request("GET", "/status"));

            route.Invoke().StatusCode.Should().Equal(HttpStatusCode.OK);
        }
    }
}