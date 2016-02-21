namespace TheSchool.Web.Areas.Teacher.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Common;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Services.Data;
    using Services.Web;
    using ViewModels;

    [Authorize(Roles = GlobalConstants.TeacherRoleName)]
    public class TutorClassController : Controller
    {
        private const decimal StudentsPerPage = 4m;
        private readonly IStudentsService students;
        private readonly ICacheService cash;

        public TutorClassController(IStudentsService students, ICacheService cash)
        {
            this.students = students;
            this.cash = cash;
        }

        public ActionResult Index(int id = 1)
        {
            var teacherId = this.User.Identity.GetUserId();
            var studentsCount = this.students
                .GetByClassTutorId(teacherId)
                .Count();
            var page = id;
            var pages = (int)Math.Ceiling(studentsCount / StudentsPerPage);
            var skip = (page - 1) * StudentsPerPage;

            var studentsModel = this.cash.Get(
                $"Students_{teacherId}_{page}",
                () => this.students
                    .GetByClassTutorId(teacherId)
                    .OrderBy(s => s.FirstName)
                    .ThenBy(s => s.SecondName)
                    .Skip((int)skip)
                    .Take((int)StudentsPerPage)
                    .To<StudentViewModel>()
                    .ToList(),
                60 * 60);

            var viewModel = new TutorClassIndexViewModel()
            {
                Students = studentsModel,
                ClassName = "Vtori be",
                Page = page,
                Pages = pages,
            };
            return this.View(viewModel);
        }
    }
}