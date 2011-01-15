namespace Autommo.Tests
{
    #region Using Directives

    using System.Net;

    using Autommo.Dto;

    using Nancy;
    using Nancy.Routing;

    using Should.Fluent;

    using Xunit;

    #endregion

    public class MobsModuleTests
    {
        private readonly MobsModule _test = new MobsModule();

        [Fact]
        public void PostMob_WhenMobCanBeCreated_GivesCreatedResponse()
        {
            IRoute route = _test.GetRouteForRequest(new Request("POST", "/mob"));

            route.Invoke().StatusCode.Should().Equal(HttpStatusCode.Created);
        }

        [Fact]
        public void PostMob_WhenMobCanBeCreated_GivesResponseContainingMob()
        {
            IRoute route = _test.GetRouteForRequest(new Request("POST", "/mob"));

            route.Invoke().GetDeserializedContents<Mob>().Should().Be.OfType(typeof(Mob));
        }
    }
}