using System.ComponentModel.Composition;
using System.Net;
using Nancy;

namespace Autommo
{
    [Export(typeof (NancyModule))]
    public class WorldModule : NancyModule
    {
        [ImportingConstructor]
        public WorldModule()
        {
            Get["/status"] = parameters => { return new Response {StatusCode = HttpStatusCode.OK}; };
        }
    }
}