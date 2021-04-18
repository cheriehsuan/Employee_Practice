using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace practice_0004
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{Emp_id}",
                defaults: new { Emp_id = RouteParameter.Optional }
            );
        }
    }
}
