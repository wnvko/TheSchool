namespace TheSchool.Web.Routes.Tests
{
    using System.Web.Routing;
    using Controllers;
    using MvcRouteTester;
    using NUnit.Framework;
    using ViewModels.News;

    [TestFixture]
    public class TheSchoolRouteTests
    {
        [Test]
        public void TestNewsDetailsRouteById()
        {
            var routesCollection = new RouteCollection();
            const string Url = @"/News/Details/95";

            RouteConfig.RegisterRoutes(routesCollection);

            routesCollection.ShouldMap(Url)
                .To<NewsController>(
                    c => c.Details(95));
        }

        [Test]
        public void TestNewsIndexRouteById()
        {
            var routesCollection = new RouteCollection();
            const string Url = @"/News/Index/2/vote";

            RouteConfig.RegisterRoutes(routesCollection);

            routesCollection.ShouldMap(Url)
                .To<NewsController>(
                    c => c.Index("vote", 2));
        }

        [Test]
        public void TestNewsAddNewsGetRoute()
        {
            var routesCollection = new RouteCollection();
            const string Url = @"/News/AddNews";

            RouteConfig.RegisterRoutes(routesCollection);

            routesCollection.ShouldMap(Url)
                .To<NewsController>(
                    c => c.AddNews());
        }

        [Test]
        public void TestNewsAddNewsPostRoute()
        {
            var routesCollection = new RouteCollection();
            const string Url = @"/News/AddNews";

            RouteConfig.RegisterRoutes(routesCollection);

            routesCollection.ShouldMap(Url)
                .To<NewsController>(
                    c => c.AddNews(new NewsInputModel()));
        }

        [Test]
        public void TestHomeIndexRoute()
        {
            var routesCollection = new RouteCollection();
            const string Url = @"/Home/Index";

            RouteConfig.RegisterRoutes(routesCollection);

            routesCollection.ShouldMap(Url)
                .To<HomeController>(
                    c => c.Index());
        }
    }
}
