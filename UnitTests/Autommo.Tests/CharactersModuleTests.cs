namespace Autommo.Tests
{
    using System.Net;

    using Autommo.Dto;

    using Nancy;
    using Nancy.Routing;

    using Should.Fluent;

    using Xunit;

    public class CharactersModuleTests
    {
        private readonly CharactersModule _test = new CharactersModule();

        [Fact]
        public void GetCharacter_WhenGivenAKnownCharacterInUri_GivesOKResponse()
        {
            IRoute route = _test.GetRouteForRequest(new Request("GET", "/character/test"));

            route.Invoke().StatusCode.Should().Equal(HttpStatusCode.OK);
        }

        [Fact]
        public void GetCharacter_WhenGivenAKnownCharacterInUri_IncludesCharacterInResponse()
        {
            IRoute route = _test.GetRouteForRequest(new Request("GET", "/character/test"));

            route.Invoke().GetDeserializedContents<Character>().Should().Not.Be.Null();
        }

        [Fact]
        public void GetCharacter_WhenGivenAnUnrecognisedCharacterInUri_GivesNotFoundResponse()
        {
            IRoute route = _test.GetRouteForRequest(new Request("GET", "/character/thisdoesnotexist"));

            route.Invoke().StatusCode.Should().Equal(HttpStatusCode.NotFound);
        }

        [Fact]
        public void PostRoute_WhenRouteCanBeExtended_GivesCreatedResponse()
        {
            IRoute route = _test.GetRouteForRequest(new Request("POST", "/character/test/route"));

            route.Invoke().StatusCode.Should().Equal(HttpStatusCode.Created);
        }
    }
}