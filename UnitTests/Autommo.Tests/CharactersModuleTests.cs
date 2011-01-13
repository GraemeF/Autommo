namespace Autommo.Tests
{
    using System.Linq;
    using System.Net;

    using Autommo.Dto;
    using Autommo.Game.Interfaces;

    using Moq;

    using Nancy;
    using Nancy.Routing;

    using ReactiveXaml;

    using Should.Fluent;

    using Xunit;

    public class CharactersModuleTests
    {
        private readonly CharactersModule _test;

        private readonly IWorld _world;

        public CharactersModuleTests()
        {
            var characters = new ReactiveCollection<ICharacter>
                                 {
                                     Mocks.Of<ICharacter>().
                                         First(x => x.Id == new CharacterId("test"))
                                 };

            _world = Mocks.Of<IWorld>().
                First(x => x.Characters == characters);

            _test = new CharactersModule(_world);
        }

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