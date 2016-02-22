namespace TheSchool.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Data;
    using TheSchool.Common;
    using ViewModels.Discipline;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class DisciplineController : Controller
    {
        private readonly IDisciplinesSerivice disciplines;

        public DisciplineController(IDisciplinesSerivice disciplines)
        {
            this.disciplines = disciplines;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, DisciplineViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var discipline = new Discipline();
                this.UpdateDiscilineFromModel(model, discipline);

                this.disciplines.Add(discipline);
                model.Id = discipline.Id;
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var disciplines = this.disciplines.All().To<DisciplineViewModel>();
            return this.Json(disciplines.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, DisciplineViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var discipline = this.disciplines.GetById(model.Id);
                if (discipline != null)
                {
                    this.UpdateDiscilineFromModel(model, discipline);
                    this.disciplines.Save();
                }
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request, DisciplineViewModel model)
        {
            if (model != null)
            {
                var discipline = this.disciplines.GetById(model.Id);
                this.disciplines.Delete(discipline);
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        private void UpdateDiscilineFromModel(DisciplineViewModel model, Discipline discipline)
        {
            discipline.Name = model.Name;

            // discipline.Divisions = model.Divisions;
            // discipline.Marks = model.Marks;
            // discipline.Teachers = model.Teachers;
        }
    }
}
