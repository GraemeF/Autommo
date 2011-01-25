namespace Autommo.Tests
{
    #region Using Directives

    using System.Collections.Generic;
    using System.Linq;
    using System.Net;

    using Autommo.Dto;
    using Autommo.Game.Interfaces;

    using Moq;

    using Nancy;

    using ReactiveUI;

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
            _test.InvokeRouteForRequest(new Request("GET", "http://localhost/character/test", "http")).
                StatusCode.Should().Equal(HttpStatusCode.OK);
        }

        [Fact]
        public void GetCharacter_WhenGivenAKnownCharacterInUri_IncludesCharacterInResponse()
        {
            _test.InvokeRouteForRequest(new Request("GET", "http://localhost/character/test", "http")).
                GetDeserializedContents<Character>().Position.Location.BaseCentre.
                Should().Equal(_characterLocation);
        }

        [Fact]
        public void GetCharacter_WhenGivenAnUnrecognisedCharacterInUri_GivesNotFoundResponse()
        {
            _test.InvokeRouteForRequest(new Request("GET", "http://localhost/character/thisdoesnotexist", "http")).
                StatusCode.Should().Equal(HttpStatusCode.NotFound);
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
                Should().Equal("/character/bob");
        }

        [Fact]
        public void PostRoute_WhenRouteCanBeExtended_GivesCreatedResponse()
        {
            _test.InvokeRouteForRequest(new Request("POST", "http://localhost/character/test/route", "http")).
                StatusCode.Should().Equal(HttpStatusCode.Created);
        }

        private Response CreateCharacterCalledBob()
        {
            var request = new Request("POST",
                                      "http://localhost/character",
                                      new Dictionary<string, IEnumerable<string>>(),
                                      new Character
                                          {
                                              Name = "Bob"
                                          }.ToRequestBody(),
                                      "http");

            return _test.InvokeRouteForRequest(request);
        }
    }
}