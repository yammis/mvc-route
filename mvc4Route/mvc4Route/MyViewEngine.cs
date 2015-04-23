using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvc4Route
{
    public class MyViewEngine:System.Web.Mvc.RazorViewEngine
    {
        public MyViewEngine()
        {
            {
                ViewLocationFormats = new[]
        {
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml",
                "~/Views/Admin/{1}/{0}.cshtml",
                "~/Views/Page/{1}/{0}.cshtml",
                "~/Views/user/{1}/{0}.cshtml",
        };
            }
        }
       

        public override System.Web.Mvc.ViewEngineResult FindView(System.Web.Mvc.ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            return base.FindView(controllerContext, viewName, masterName, useCache);
        }
    }
}