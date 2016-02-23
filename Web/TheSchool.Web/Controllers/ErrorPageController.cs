namespace TheSchool.Web.Controllers
{
    using System.Web.Mvc;

    public class ErrorPageController : BaseController
    {
        public ActionResult Index()
        {
            foreach (var modelValue in this.ModelState.Values)
            {
                modelValue.Errors.Clear();
            }

            return this.View();
        }

        public ActionResult Error(int id)
        {
            this.Response.StatusCode = id;
            foreach (var modelValue in this.ModelState.Values)
            {
                modelValue.Errors.Clear();
            }

            return this.View();
        }
    }
}
