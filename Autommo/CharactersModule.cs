namespace Autommo
{
    #region Using Directives

    using System;
    using System.Linq;
    using System.Net;

    using AutoMapper;

    using Autommo.Dto;
    using Autommo.Game.Interfaces;

    using Nancy;
    using Nancy.Formatters.Responses;

    #endregion

    public class CharactersModule : NancyModule
    {
        private const string CharacterIdPath = CharacterPath + "/{id}";

        private const string CharacterPath = "/character";

        private const string RoutePath = CharacterIdPath + "/route";

        private readonly Func<CharacterId, ICharacter> _characterFactory;

        private readonly IWorld _world;

        public CharactersModule(IWorld world, Func<CharacterId, ICharacter> characterFactory)
        {
            Mapper.CreateMap<ICharacter, Character>();

            _world = world;
            _characterFactory = characterFactory;

            RegisterRoutes();
        }

        private static CharacterId GetCharacterId(Character character)
        {
            return new CharacterId(character.Name);
        }

        private static void SetCharacterLocationHeader(CharacterId id, JsonResponse<Character> response)
        {
            response.Headers["Location"] = CharacterIdPath.Replace("{id}", id.ToString().ToLowerInvariant());
        }

        private ICharacter AddNewCharacterToWorld(CharacterId characterId)
        {
            ICharacter character = _characterFactory(characterId);
            _world.Characters.Add(character);

            return character;
        }

        private JsonResponse<Character> CreateCharacter(CharacterId id)
        {
            ICharacter newCharacter = AddNewCharacterToWorld(id);
            var response =
                new JsonResponse<Character>(Mapper.Map<ICharacter, Character>(newCharacter))
                    {
                        StatusCode = HttpStatusCode.Created
                    };
            SetCharacterLocationHeader(id, response);
            return response;
        }

        private Response GetCharacter(CharacterId id)
        {
            ICharacter character = _world.Characters.FirstOrDefault(x => x.Id == id);
            return character == null
                       ? new Response
                             {
                                 StatusCode = HttpStatusCode.NotFound
                             }
                       : new JsonResponse<Character>(Mapper.Map<ICharacter, Character>(character))
                             {
                                 StatusCode = HttpStatusCode.OK, 
                                 ContentType = Schema.ContentType
                             };
        }

        private void RegisterRoutes()
        {
            Get[CharacterIdPath] = parameters => GetCharacter(new CharacterId((string)parameters.id));
            Post[CharacterPath] = parameters => CreateCharacter(GetCharacterId(Request.GetBodyAs<Character>()));
            Post[RoutePath] = parameters =>
                {
                    return
                        new Response
                            {
                                StatusCode = HttpStatusCode.Created
                            };
                };
        }
    }
}