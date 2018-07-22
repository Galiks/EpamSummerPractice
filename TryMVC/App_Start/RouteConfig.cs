using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TryMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            #region Maps for Users
            routes.MapRoute(
                   name: "create-user",
                   url: "create-user/{id}",
                   defaults: new { controller = "Users", action = "Create", id = UrlParameter.Optional }
                   );

            routes.MapRoute(
                name: "users",
                url: "users",
                defaults: new { controller = "Users", action = "Index" });

            routes.MapRoute(
                name: "edit-user",
                url: "user/{id}/edit",
                defaults: new { controller = "Users", action = "Edit", id = UrlParameter.Optional });

            routes.MapRoute(
                name: "delete-user",
                url: "user/{id}/delete",
                defaults: new { controller = "Users", action = "Delete", id = UrlParameter.Optional });

            routes.MapRoute(
                name: "details-user",
                url: "user/{id}",
                defaults: new { controller = "Users", action = "Details", id = UrlParameter.Optional });

            //routes.MapRoute(
            //    name: "sort-users",
            //    url: "user/sort/",
            //    defaults: new { controller = "Users", action = "SortUsers", method = "Get", searchString = UrlParameter.Optional });

            routes.MapRoute(
                name: "user's awards",
                url: "user/{id}/awards",
                defaults: new { controller = "Users", action = "ShowAwards", id = UrlParameter.Optional });
            #endregion

            #region Maps for Awards
            routes.MapRoute(
                name: "awards",
                url: "awards",
                defaults: new { controller = "Awards", action = "Index" });

            routes.MapRoute(
                name: "create-awards",
                url: "create-award",
                defaults: new { controller = "Awards", action = "Create" });

            routes.MapRoute(
                name: "details-award",
                url: "award/{id}",
                defaults: new { controller = "Awards", action = "Details", id = UrlParameter.Optional });

            routes.MapRoute(
                name: "edit-award",
                url: "award/{id}/edit",
                defaults: new { controller = "Awards", action = "Edit", id = UrlParameter.Optional });

            routes.MapRoute(
                name: "delete-award",
                url: "award/{id}/delete",
                defaults: new { controller = "Awards", action = "Delete", id = UrlParameter.Optional });
            #endregion

            #region Maps for Rewarding
            routes.MapRoute(
                name: "rewarding",
                url: "award-user/{id}",
                defaults: new { controller = "Users", action = "Rewarding", id = UrlParameter.Optional });
            #endregion

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
