namespace TheSchool.Services.Data
{
    using System.Linq;
    using TheSchool.Data.Models;

    public interface IDisciplinesSerivice
    {
        Discipline Add(Discipline discipline);

        IQueryable<Discipline> All();

        void Delete(Discipline discipline);

        Discipline GetById(int id);

        void Save();
    }
}
