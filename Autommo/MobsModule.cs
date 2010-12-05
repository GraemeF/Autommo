using Nancy;

namespace Autommo
{
    public class MobsModule : NancyModule
    {
        public MobsModule()
        {
            Put["/mob"] = parameters => { return "This is the site route"; };
            Get["/mob"] = parameters => { return "Hello, I'm Nancy!"; };
        }
    }
}