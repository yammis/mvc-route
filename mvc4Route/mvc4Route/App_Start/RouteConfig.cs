using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace mvc4Route
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "admin/{controller}/{action}/{id}",
                defaults: new { controller = "test", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "page",
                url: "page/{controller}/{action}/{id}/{*catchall}",
                defaults: new { controller = "product", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "user",
                url: "user/{controller}/{action}/{id}",
                defaults: new { controller = "list", action = "Index", id = UrlParameter.Optional },
                constraints: new { constraint = new CustomerConstraints("IE"),controller="^l.*" },
                namespaces: new[] { "mvc4Route.Controllers.Page" }
                );
            
        }

        public class CustomerConstraints : IRouteConstraint
        {
            private string userAgent;
            public CustomerConstraints(string agentArgs){
                this.userAgent = agentArgs;
            }

            public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
            {
                return httpContext.Request.UserAgent.Contains(userAgent) && httpContext.Request.UserAgent != null;
            }
        }
    }
}