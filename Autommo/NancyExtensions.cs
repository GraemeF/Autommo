namespace Autommo
{
    #region Using Directives

    using System.IO;

    using Nancy;

    using Newtonsoft.Json;

    #endregion

    public static class NancyExtensions
    {
        public static TContents GetBodyAs<TContents>(this IRequest request)
        {
            using (var reader = new StreamReader(request.Body))
                return (TContents)new JsonSerializer().Deserialize(reader, typeof(TContents));
        }
    }
}