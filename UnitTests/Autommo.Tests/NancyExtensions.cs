namespace Autommo.Tests
{
    #region Using Directives

    using System;
    using System.IO;
    using System.Linq;

    using Nancy;

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

        public static Response InvokeRouteForRequest(this NancyModule module, 
                                                     Request request, 
                                                     string route = null, 
                                                     DynamicDictionary parameters = null)
        {
            module.Request = request;
            return module.Routes.
                First(x => x.Description.Method == module.Request.Method &&
                           x.Description.Path == (route ?? new Uri(module.Request.Uri).PathAndQuery)).
                Action(parameters);
        }

        public static Stream ToRequestBody<TContents>(this TContents contents)
        {
            var memory = new MemoryStream();
            var writer = new StreamWriter(memory);
            string serializedObject = JsonConvert.SerializeObject(contents);
            writer.Write(serializedObject);
            writer.Flush();
            memory.Position = 0;
            return memory;
        }
    }
}