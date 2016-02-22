namespace TheSchool.Services.Data
{
    using System;
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

        public Discipline Add(Discipline discipline)
        {
            this.disciplines.Add(discipline);
            this.disciplines.Save();
            return discipline;
        }

        public IQueryable<Discipline> All()
        {
            return this.disciplines.All();
        }

        public void Delete(Discipline discipline)
        {
            this.disciplines.Delete(discipline);
        }

        public Discipline GetById(int id)
        {
            return this.disciplines.GetById(id);
        }

        public void Save()
        {
            this.disciplines.Save();
        }
    }
}
