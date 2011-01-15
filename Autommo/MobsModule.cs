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
    public class MobsModule : NancyModule
    {
        [ImportingConstructor]
        public MobsModule()
        {
            Post["/mob"] = parameters =>
                {
                    return
                        new JsonResponse<Mob>(new Mob
                                                  {
                                                      Location = new WorldLocation(), 
                                                      Status = "Idle"
                                                  })
                            {
                                ContentType = Schema.ContentType, 
                                StatusCode = HttpStatusCode.Created
                            };
                };
        }
    }
}