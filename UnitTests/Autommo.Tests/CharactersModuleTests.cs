namespace Autommo.Tests
{
    using System.Net;

    using Nancy;
    using Nancy.Routing;

    using Should.Fluent;

    using Xunit;

    public class CharactersModuleTests
    {
        private readonly CharactersModule _test = new CharactersModule();

        [Fact]
        public void PostRoute_WhenRouteCanBeExtended_GivesCreatedResponse()
        {
            IRoute route = _test.GetRouteForRequest(new Request("POST", "/character/test/route"));

            route.Invoke().StatusCode.Should().Equal(HttpStatusCode.Created);
        }
    }
}