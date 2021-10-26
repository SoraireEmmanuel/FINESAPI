using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using FinesApi.Controllers;
using System.Web.Http.Cors;

namespace FinesApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web
            
            var enableCorsAttribute = new EnableCorsAttribute("*","Origin, Content-Type, Accept","GET, POST, PUT, OPTIONS");
            config.EnableCors(enableCorsAttribute);

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.MessageHandlers.Add(new TokenValidationHandler());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
