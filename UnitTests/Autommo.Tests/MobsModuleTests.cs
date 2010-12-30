using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Autommo.Dto;
using JsonFx.Json;
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

        [Fact]
        public void PostMob_WhenMobCanBeCreated_GivesResponseContainingMob()
        {
            IRoute route = GetRoute(new Request("POST", "/mob"));

            GetDeserializedContentsFromResponse<Mob>(route.Invoke()).Should().Be.OfType(typeof (Mob));
        }

        private IRoute GetRoute(Request request)
        {
            var modules = new[] {_test};
            IEnumerable<RouteDescription> descriptions = modules.SelectMany(x => x.GetRouteDescription(request));

            return _resolver.GetRoute(request, descriptions);
        }

        private static TContents GetDeserializedContentsFromResponse<TContents>(Response response)
        {
            var memory = new MemoryStream();
            response.Contents.Invoke(memory);
            memory.Position = 0;

            using (var reader = new StreamReader(memory))
                return new JsonReader().Read<TContents>(reader);
        }
    }
}