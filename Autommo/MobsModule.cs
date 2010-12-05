using System.Net;
using Nancy;

namespace Autommo
{
    public class MobsModule : NancyModule
    {
        public MobsModule()
        {
            Post["/mob"] = parameters => { return HttpStatusCode.Created; };
        }
    }
}