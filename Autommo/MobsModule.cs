using System.ComponentModel.Composition;
using System.IO;
using System.Net;
using Autommo.Dto;
using Nancy;
using Nancy.Formatters.Responses;

namespace Autommo
{
    [Export(typeof (NancyModule))]
    public class MobsModule : NancyModule
    {
        public MobsModule()
        {
            Post["/mob"] = parameters =>
                               {
                                   return new JsonResponse<Mob>(new Mob())
                                              {
                                                  ContentType = "application/vnd.autommo+json",
                                                  StatusCode = HttpStatusCode.Created
                                              };
                               };
        }
    }
}