using System.ComponentModel.Composition;
using System.IO;
using System.Net;
using Nancy;

namespace Autommo
{
    [Export(typeof (NancyModule))]
    public class MobsModule : NancyModule
    {
        public MobsModule()
        {
            Post["/mob"] = parameters =>
                               {
                                   return new Response
                                              {
                                                  Contents = GetMob,
                                                  ContentType = "application/vnd.autommo+xml",
                                                  StatusCode = HttpStatusCode.Created
                                              };
                               };
        }

        private void GetMob(Stream stream)
        {
            new StreamWriter(stream) {AutoFlush = true}.Write("<mob/>");
        }
    }
}