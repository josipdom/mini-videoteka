using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Videoteka
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var opcije = config.Formatters.JsonFormatter.SerializerSettings;
            opcije.ContractResolver = new CamelCasePropertyNamesContractResolver();
            opcije.Formatting = Formatting.Indented;
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
