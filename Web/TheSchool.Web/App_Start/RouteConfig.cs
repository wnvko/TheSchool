namespace TheSchool.Web
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });
            routes.MapRoute(
                name: "NewsIndex",
                url: "News/Index/{id}/{order}",
                defaults: new { controller = "News", action = "Index", id = UrlParameter.Optional, order = UrlParameter.Optional });
        }
    }
}
