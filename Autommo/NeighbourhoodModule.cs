namespace Autommo
{
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Net;

    using Autommo.Dto;

    using Nancy;
    using Nancy.Formatters.Responses;

    [Export(typeof(NancyModule))]
    public class NeighbourhoodModule : NancyModule
    {
        [ImportingConstructor]
        public NeighbourhoodModule()
        {
            Get["/neighbourhood"] = parameters =>
                {
                    return
                        new JsonResponse<Neighbourhood>(new Neighbourhood
                                                            {
                                                                Mobs = new Mob[]
                                                                           {
                                                                               new Mob()
                                                                           }
                                                            })
                            {
                                ContentType = Schema.ContentType,
                                StatusCode = HttpStatusCode.OK
                            };
                };
        }
    }
}