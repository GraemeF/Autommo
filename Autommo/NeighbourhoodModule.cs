namespace Autommo
{
    #region Using Directives

    using System.Net;

    using Autommo.Dto;

    using Nancy;
    using Nancy.Formatters.Responses;

    #endregion

    public class NeighbourhoodModule : NancyModule
    {
        public NeighbourhoodModule()
        {
            Get["/neighbourhood"] = parameters =>
                {
                    return
                        new JsonResponse<Neighbourhood>(new Neighbourhood
                                                            {
                                                                Mobs = new[]
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