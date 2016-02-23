namespace TheSchool.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;
    using Common;
    using Data;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Services.Data;
    using TheSchool.Data.Models;
    using ViewModels.Teacher;
    using Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class TeacherController : BaseController
    {
        private readonly ITeachersService teachers;

        public TeacherController(ITeachersService teachers, IDisciplinesSerivice disciplines)
        {
            this.teachers = teachers;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, TeacherViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var teacher = new Teacher();
                this.UpdateTeacherFromModel(model, teacher);

                var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
                var userManager = new UserManager<ApplicationUser>(userStore);
                var result = userManager.Create(teacher, teacher.Email);

                if (result.Succeeded)
                {
                    userManager.AddToRole(teacher.Id, GlobalConstants.TeacherRoleName);
                    model.Id = teacher.Id;
                }
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var teachers = this.teachers.All().To<TeacherViewModel>();
            return this.Json(teachers.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, TeacherViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var teacher = this.teachers.GetById(model.Id);
                if (teacher != null)
                {
                    this.UpdateTeacherFromModel(model, teacher);
                    this.teachers.Save();
                }
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request, TeacherViewModel model)
        {
            if (model != null)
            {
                var teacher = this.teachers.GetById(model.Id);
                this.teachers.Delete(teacher);
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        private void UpdateTeacherFromModel(TeacherViewModel model, Teacher teacher)
        {
            teacher.FirstName = model.FirstName;
            teacher.SecondName = model.SecondName;
            teacher.Email = $"{model.FirstName}.{model.SecondName}@theschool.com";
            teacher.UserName = teacher.Email;

            // teacher.Divisions = model.Divisions;
            // teacher.Marks = model.Marks;
        }
    }
}
