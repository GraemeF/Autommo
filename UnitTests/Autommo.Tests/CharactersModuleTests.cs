namespace Autommo.Tests
{
    #region Using Directives

    using System.Collections.Generic;

    using Autommo.Dto;
    using Autommo.Game.Interfaces;

    using Nancy;

    using NSubstitute;

    using ReactiveUI;

    using Should.Fluent;

    using Xunit;

    #endregion

    public class CharactersModuleTests
    {
        private readonly ICharacter _addedCharacter = Substitute.For<ICharacter>();

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

            var testCharacter = Substitute.For<ICharacter>();
            testCharacter.Id.Returns(new CharacterId("test"));
            testCharacter.Position.Returns(new UnitPosition(new Cylinder(_characterLocation, 1M), 
                                                            0M));
            var characters = new ReactiveCollection<ICharacter>
                                 {
                                     testCharacter
                                 };

            _world = Substitute.For<IWorld>();
            _world.Characters.Returns(characters);

            _test = new CharactersModule(_world, _ => _addedCharacter);
        }

        [Fact]
        public void GetCharacter_WhenGivenAKnownCharacterInUri_GivesOKResponse()
        {
            var parameters = new DynamicDictionary();
            parameters["id"] = "test";

            _test.InvokeRouteForRequest(new Request("GET", 
                                                    "http://localhost/character/test", 
                                                    "http"), 
                                        "/character/{id}", 
                                        parameters).
                StatusCode.Should().Equal(HttpStatusCode.OK);
        }

        [Fact]
        public void GetCharacter_WhenGivenAKnownCharacterInUri_IncludesCharacterInResponse()
        {
            var parameters = new DynamicDictionary();
            parameters["id"] = "test";

            _test.InvokeRouteForRequest(new Request("GET", 
                                                    "http://localhost/character/test", 
                                                    "http"), 
                                        "/character/{id}", 
                                        parameters).
                GetDeserializedContents<Character>().Position.Location.BaseCentre.
                Should().Equal(_characterLocation);
        }

        [Fact]
        public void GetCharacter_WhenGivenAnUnrecognisedCharacterInUri_GivesNotFoundResponse()
        {
            var parameters = new DynamicDictionary();
            parameters["id"] = "thisdoesnotexist";

            _test.InvokeRouteForRequest(new Request("GET", 
                                                    "http://localhost/character/thisdoesnotexist", 
                                                    "http"), 
                                        "/character/{id}", 
                                        parameters).
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
            CreateCharacterCalledBob().Headers["Location"].
                Should().Equal("/character/bob");
        }

        [Fact]
        public void PostRoute_WhenRouteCanBeExtended_GivesCreatedResponse()
        {
            _test.InvokeRouteForRequest(new Request("POST", "http://localhost/character/test/route", "http"), 
                                        "/character/{id}/route").
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

            return _test.InvokeRouteForRequest(request, "/character");
        }
    }
}