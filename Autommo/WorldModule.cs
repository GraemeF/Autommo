namespace Autommo
{
    using System.ComponentModel.Composition;
    using System.Net;

    using Nancy;

    [Export(typeof(NancyModule))]
    public class WorldModule : NancyModule
    {
        [ImportingConstructor]
        public WorldModule()
        {
            Get["/status"] = parameters =>
                {
                    return new Response
                               {
                                   StatusCode = HttpStatusCode.OK
                               };
                };
        }
    }
}