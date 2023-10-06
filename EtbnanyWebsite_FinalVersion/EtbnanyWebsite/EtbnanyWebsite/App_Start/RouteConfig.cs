using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EtbnanyWebsite
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "signin",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Etbnany", action = "SignIn", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "aboutus",
                url: "{controller}/aboutus"
            );

            routes.MapRoute(
                name: "home",
                url: "{controller}/home"
            );

            routes.MapRoute(
                name: "signup",
                url: "{controller}/signup"
            );


            routes.MapRoute(
               name: "adoption",
               url: "{controller}/adoption"
           );


            routes.MapRoute(
              name: "contactus",
              url: "{controller}/contactus"
          );

            routes.MapRoute(
              name: "donation",
              url: "{controller}/donation"
          );

            routes.MapRoute(
             name: "profile",
             url: "{controller}/profile"
         );
        }
    }
}
