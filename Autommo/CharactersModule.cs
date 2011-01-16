namespace Autommo
{
    #region Using Directives

    using System;
    using System.ComponentModel.Composition;
    using System.Linq;
    using System.Net;

    using AutoMapper;

    using Autommo.Dto;
    using Autommo.Game.Interfaces;

    using Nancy;
    using Nancy.Formatters.Responses;

    #endregion

    [Export(typeof(NancyModule))]
    public class CharactersModule : NancyModule
    {
        private const string CharacterPath = "/character";
        private const string CharacterIdPath = CharacterPath+"/{id}";

        private const string RoutePath = CharacterPath + "/route";

        private readonly Func<CharacterId, ICharacter> _characterFactory;

        private readonly IWorld _world;

        [ImportingConstructor]
        public CharactersModule(IWorld world, Func<CharacterId, ICharacter> characterFactory)
        {
            Mapper.CreateMap<ICharacter, Character>();

            _world = world;
            _characterFactory = characterFactory;
            RegisterRoutes();
        }

        private ICharacter AddCharacter(CharacterId characterId)
        {
            ICharacter character = _characterFactory(characterId);
            _world.Characters.Add(character);

            return character;
        }

        private JsonResponse<Character> CreateCharacter(Character character)
        {
            var response = new JsonResponse<Character>(
                Mapper.Map<ICharacter, Character>(AddCharacter(new CharacterId(character.Name))))
                               {
                                   StatusCode = HttpStatusCode.Created
                               };
            response.Headers["Location"] = new[] { CharacterPath.Replace("{id}", character.Name) };
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
            Post[CharacterPath] = parameters => CreateCharacter(parameters.Body);
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