namespace Autommo.Tests
{
    #region Using Directives

    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using JsonFx.Json;

    using Nancy;
    using Nancy.Routing;

    #endregion

    public static class NancyExtensions
    {
        public static TContents GetDeserializedContents<TContents>(this Response response)
        {
            var memory = new MemoryStream();
            response.Contents.Invoke(memory);
            memory.Position = 0;

            using (var reader = new StreamReader(memory))
                return new JsonReader().Read<TContents>(reader);
        }

        public static IRoute GetRouteForRequest(this NancyModule module, Request request)
        {
            var modules = new[] { module };
            IEnumerable<RouteDescription> descriptions =
                modules.SelectMany(x => Nancy.Extensions.NancyExtensions.GetRouteDescription(x, request));

            return new RouteResolver().GetRoute(request, descriptions);
        }
    }
}