namespace Autommo
{
    #region Using Directives

    using System.ComponentModel.Composition;
    using System.Net;

    using Autommo.Dto;

    using Nancy;
    using Nancy.Formatters.Responses;

    #endregion

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