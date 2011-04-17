namespace Autommo.Tests
{
    #region Using Directives

    using System.Collections.Generic;

    using Autommo.Dto;
    using Autommo.Game.Interfaces;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using NSubstitute;

    using Nancy;

    using ReactiveUI;

    using Should.Fluent;

    #endregion

    [TestClass]
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

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
        public void PostCharacter_WhenGivenACharacterWithUnusedName_GivesCreatedResponse()
        {
            CreateCharacterCalledBob().StatusCode.Should().Equal(HttpStatusCode.Created);
        }

        [TestMethod]
        public void PostCharacter_WhenGivenACharacterWithUnusedName_GivesLocationInResponse()
        {
            CreateCharacterCalledBob().Headers["Location"].
                Should().Equal("/character/bob");
        }

        [TestMethod]
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