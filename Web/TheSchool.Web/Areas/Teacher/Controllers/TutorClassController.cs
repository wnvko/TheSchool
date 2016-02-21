namespace TheSchool.Web.Areas.Teacher.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Common;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Services.Data;
    using ViewModels;
    using Web.Controllers;
    using Web.ViewModels.Students;
    [Authorize(Roles = GlobalConstants.TeacherRoleName)]
    public class TutorClassController : BaseController
    {
        private const decimal StudentsPerPage = 4m;
        private readonly IStudentsService students;

        public TutorClassController(IStudentsService students)
        {
            this.students = students;
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

            var studentsModel = this.Cache.Get(
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
                ClassName = studentsModel.FirstOrDefault().Division,
                Page = page,
                Pages = pages,
            };
            return this.View(viewModel);
        }
    }
}