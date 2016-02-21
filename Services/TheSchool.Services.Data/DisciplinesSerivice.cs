namespace TheSchool.Services.Data
{
    using System.Linq;
    using TheSchool.Data.Common;
    using TheSchool.Data.Models;

    public class DisciplinesSerivice : IDisciplinesSerivice
    {
        private readonly IDbRepositoryInty<Discipline> disciplines;

        public DisciplinesSerivice(IDbRepositoryInty<Discipline> disciplines)
        {
            this.disciplines = disciplines;
        }

        public IQueryable<Discipline> All()
        {
            return this.disciplines.All();
        }

        public Discipline GetById(int id)
        {
            return this.disciplines.GetById(id);
        }
    }
}
