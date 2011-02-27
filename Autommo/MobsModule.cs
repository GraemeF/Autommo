﻿namespace Autommo
{
    #region Using Directives

    using Autommo.Dto;

    using Nancy;
    using Nancy.Responses;

    #endregion

    public class MobsModule : NancyModule
    {
        public MobsModule()
        {
            Post["/mob"] = parameters =>
                {
                    return
                        new JsonResponse<Mob>(new Mob
                                                  {
                                                      Location = new WorldLocation(), 
                                                      Status = "Idle"
                                                  })
                            {
                                ContentType = Schema.ContentType, 
                                StatusCode = HttpStatusCode.Created
                            };
                };
        }
    }
}