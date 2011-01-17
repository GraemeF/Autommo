namespace Autommo.Tests
{
    #region Using Directives

    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Nancy;
    using Nancy.Routing;

    using Newtonsoft.Json;

    #endregion

    public static class NancyExtensions
    {
        public static TContents GetDeserializedContents<TContents>(this Response response)
        {
            var memory = new MemoryStream();
            response.Contents.Invoke(memory);
            memory.Position = 0;
            using (var reader = new StreamReader(memory))
                return JsonConvert.DeserializeObject<TContents>(reader.ReadToEnd());
        }

        public static IRoute GetRouteForRequest(this NancyModule module, Request request)
        {
            var modules = new[] { module };
            IEnumerable<RouteDescription> descriptions =
                modules.SelectMany(x => Nancy.Extensions.NancyExtensions.GetRouteDescription(x, request));

            return new RouteResolver().GetRoute(request, descriptions);
        }

        public static Stream ToRequestBody<TContents>(this TContents contents)
        {
            var memory = new MemoryStream();
            var writer = new StreamWriter(memory);
            var serializedObject = JsonConvert.SerializeObject(contents);
            writer.Write(serializedObject);
            writer.Flush();
            memory.Position = 0;
            return memory;
        }
    }
}