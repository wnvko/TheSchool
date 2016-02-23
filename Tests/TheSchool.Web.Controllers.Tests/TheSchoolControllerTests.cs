namespace TheSchool.Web.Controllers.Tests
{
    using System.Reflection;
    using System.Web.Mvc;
    using Controllers;
    using Infrastructure.Mapping;
    using Moq;
    using NUnit.Framework;
    using Services.Data;

    [TestFixture]

    public class TheSchoolControllerTests
    {
        [Test]
        public void HomeIndexReturnsCorectView()
        {
            /*
             var autoMapperConfig = new AutoMapperConfig();
             autoMapperConfig.Execute(Assembly.GetAssembly(typeof(HomeController)));

             Mock<IStudentsService> students = new Mock<IStudentsService>();
             Mock<INewsService> news = new Mock<INewsService>();

             var contoller = new HomeController(students.Object, news.Object);
             var result = contoller.Index() as ViewResult;

             Assert.AreEqual("Index", result.ViewName);
             */
        }
    }
}
