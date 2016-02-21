namespace TheSchool.Services.Data
{
    using System.Linq;
    using TheSchool.Data.Models;

    public interface ITeachersService
    {
        Teacher Add(Teacher teacher);

        IQueryable<Teacher> All();

        void Delete(Teacher teacher);

        Teacher GetById(string id);

        void Save();
    }
}
