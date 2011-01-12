namespace Autommo
{
    using System.ComponentModel.Composition;
    using System.Net;

    using Autommo.Dto;
    using Autommo.Game.Interfaces;

    using Nancy;
    using Nancy.Formatters.Responses;

    [Export(typeof(NancyModule))]
    public class CharactersModule : NancyModule
    {
        [ImportingConstructor]
        public CharactersModule(IWorld world)
        {
            Get["/character/test"] = parameters =>
                {
                    return
                        new JsonResponse<Character>(new Character
                                                        {
                                                            Location = new WorldLocation
                                                                           {
                                                                               Position = new WorldPoint()
                                                                           }
                                                        })
                            {
                                StatusCode = HttpStatusCode.OK,
                                ContentType = Schema.ContentType
                            };
                };
            Post["/character/test/route"] = parameters =>
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