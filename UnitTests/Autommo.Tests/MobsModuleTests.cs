namespace Autommo.Tests
{
    #region Using Directives

    using System.Net;

    using Autommo.Dto;

    using Nancy;

    using Should.Fluent;

    using Xunit;

    #endregion

    public class MobsModuleTests
    {
        private readonly MobsModule _test = new MobsModule();

        [Fact]
        public void PostMob_WhenMobCanBeCreated_GivesCreatedResponse()
        {
            _test.InvokeRouteForRequest(new Request("POST", "http://localhost/mob", "http")).StatusCode.
                Should().Equal(HttpStatusCode.Created);
        }

        [Fact]
        public void PostMob_WhenMobCanBeCreated_GivesResponseContainingMob()
        {
            _test.InvokeRouteForRequest(new Request("POST", "http://localhost/mob", "http")).
                GetDeserializedContents<Mob>().Should().Be.OfType(typeof(Mob));
        }
    }
}