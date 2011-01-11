namespace Autommo
{
    using System.ComponentModel.Composition;
    using System.Net;

    using Nancy;

    [Export(typeof(NancyModule))]
    public class CharactersModule : NancyModule
    {
        [ImportingConstructor]
        public CharactersModule()
        {
            Post["/character/test/route"] = parameters =>
                {
                    return
                        new Response()
                            {
                                StatusCode = HttpStatusCode.Created
                            };
                };
        }
    }
}