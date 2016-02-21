namespace TheSchool.Services.Data
{
    using System.Linq;
    using TheSchool.Data.Models;

    public interface IStudentsService
    {
        IQueryable<Student> All();

        IQueryable<Student> GetByClassTutorId(string id);

        Student GetById(string id);

        IQueryable<Student> GetTopTenByMarks();

        void Save();
    }
}
