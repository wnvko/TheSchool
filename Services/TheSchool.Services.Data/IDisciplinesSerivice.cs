namespace TheSchool.Services.Data
{
    using System.Linq;
    using TheSchool.Data.Models;

    public interface IDisciplinesSerivice
    {
        IQueryable<Discipline> All();

        Discipline GetById(int id);
    }
}
