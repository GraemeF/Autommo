namespace Autommo.Tests
{
    #region Using Directives

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

    #endregion

    public class CharactersModuleTests
    {
        private readonly ICharacter _addedCharacter = Mock.Of<ICharacter>();

        private readonly Point _characterLocation;

        private readonly CharactersModule _test;

        private readonly IWorld _world;

        public CharactersModuleTests()
        {
            _characterLocation = new Point
                                     {
                                         X = 1M, 
                                         Y = 2M, 
                                         Z = 3M
                                     };
            var characters =
                new ReactiveCollection<ICharacter>
                    {
                        Mocks.Of<ICharacter>().
                            First(x => x.Id == new CharacterId("test") &&
                                       x.Position ==
                                       new UnitPosition(new Cylinder(_characterLocation, 1M), 
                                                        0M))
                    };

            _world = Mocks.Of<IWorld>().
                First(x => x.Characters == characters);

            _test = new CharactersModule(_world, _ => _addedCharacter);
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

            route.Invoke().GetDeserializedContents<Character>().Position.Location.BaseCentre.
                Should().Equal(_characterLocation);
        }

        [Fact]
        public void GetCharacter_WhenGivenAnUnrecognisedCharacterInUri_GivesNotFoundResponse()
        {
            IRoute route = _test.GetRouteForRequest(new Request("GET", "/character/thisdoesnotexist"));

            route.Invoke().StatusCode.Should().Equal(HttpStatusCode.NotFound);
        }

        [Fact]
        public void PostCharacter_WhenGivenACharacterWithUnusedName_GivesCreatedResponse()
        {
            CreateCharacterCalledBob().StatusCode.Should().Equal(HttpStatusCode.Created);
        }

        [Fact]
        public void PostCharacter_WhenGivenACharacterWithUnusedName_GivesLocationInResponse()
        {
            CreateCharacterCalledBob().Headers["Location"].Single().
                Should().Equal(string.Empty);
        }

        [Fact]
        public void PostRoute_WhenRouteCanBeExtended_GivesCreatedResponse()
        {
            IRoute route = _test.GetRouteForRequest(new Request("POST", "/character/test/route"));

            route.Invoke().StatusCode.Should().Equal(HttpStatusCode.Created);
        }

        private Response CreateCharacterCalledBob()
        {
            var request = new Request("POST", "/character")
                              {
                                  Body = new Character
                                             {
                                                 Name = "Bob"
                                             }.ToRequestBody()
                              };

            IRoute route = _test.GetRouteForRequest(request);

            return route.Invoke();
        }
    }
}