using System.Collections.Generic;
using System.Linq;
using System.Net;
using Nancy;
using Nancy.Extensions;
using Nancy.Routing;
using Should.Fluent;
using Xunit;

namespace Autommo.Tests
{
    public class MobsModuleTests
    {
        private readonly IRouteResolver _resolver = new RouteResolver();
        private readonly MobsModule _test = new MobsModule();

        [Fact]
        public void PostMob_WhenMobCanBeCreated_GivesCreatedResponse()
        {
            IRoute route = GetRoute(new Request("POST", "/mob"));

            route.Invoke().StatusCode.Should().Equal(HttpStatusCode.Created);
        }

        private IRoute GetRoute(Request request)
        {
            var modules = new[] {_test};
            IEnumerable<RouteDescription> descriptions = modules.SelectMany(x => x.GetRouteDescription(request));

            return _resolver.GetRoute(request, descriptions);
        }
    }
}