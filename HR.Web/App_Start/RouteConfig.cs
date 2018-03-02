using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HR.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{id}/{action}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);

            routes.MapRoute("GetDistrictByCityId",
                            "employee/getdistrictbycityid/",
                            new { controller = "Employee", action = "GetDistrictByCityId" },
                            new[] { "HR.Web.Controllers" });

            routes.MapRoute("GetTownByDistrictId",
                            "employee/GetTownByDistrictId/",
                            new { controller = "Employee", action = "GetTownByDistrictId" },
                            new[] { "HR.Web.Controllers" });

            routes.MapRoute(
                name: "Search",
                url: "{controller}/{action}/id={id}/name={name}",
                defaults: new { action = "Search" }
            );

            routes.MapRoute(
                name: "RollUp",
                url: "{controller}/{action}/{id}/{empId}",
                defaults: new
                {
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional,
                    empId = UrlParameter.Optional
                }
            );
            routes.MapRoute(
                    "Default", // Route name
                    "{controller}/{action}/{id}", // URL with parameters*
                    new
                    {
                        controller = "Home",
                        action = "Index",
                        id = UrlParameter.Optional
                    }
            );
        }
    }
}
