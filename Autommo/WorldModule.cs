﻿namespace Autommo
{
    #region Using Directives

    using Nancy;

    #endregion

    public class WorldModule : NancyModule
    {
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