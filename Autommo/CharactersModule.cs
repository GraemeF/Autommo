namespace Autommo
{
    using System.ComponentModel.Composition;
    using System.Linq;
    using System.Net;

    using AutoMapper;

    using Autommo.Dto;
    using Autommo.Game.Interfaces;

    using Nancy;
    using Nancy.Formatters.Responses;

    [Export(typeof(NancyModule))]
    public class CharactersModule : NancyModule
    {
        private readonly IWorld _world;

        [ImportingConstructor]
        public CharactersModule(IWorld world)
        {
            Mapper.CreateMap<ICharacter, Character>();

            _world = world;
            Get["/character/{id}"] = parameters => GetCharacter(new CharacterId((string)parameters.id));
            Post["/character/test/route"] = parameters =>
                {
                    return
                        new Response
                            {
                                StatusCode = HttpStatusCode.Created
                            };
                };
        }

        private Response GetCharacter(CharacterId id)
        {
            ICharacter character = _world.Characters.FirstOrDefault(x => x.Id == id);
            if (character == null)
                return new Response
                           {
                               StatusCode = HttpStatusCode.NotFound
                           };
            return
                new JsonResponse<Character>(Mapper.Map<ICharacter, Character>(character))
                    {
                        StatusCode = HttpStatusCode.OK,
                        ContentType = Schema.ContentType
                    };
        }
    }
}