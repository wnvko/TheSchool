namespace TheSchool.Services.Data
{
    using System;
    using System.Linq;
    using TheSchool.Data.Common;
    using TheSchool.Data.Models;

    public class TeachersService : ITeachersService
    {
        private readonly IDbRepositoryStringy<Teacher> teachers;

        public TeachersService(IDbRepositoryStringy<Teacher> teachers)
        {
            this.teachers = teachers;
        }

        public Teacher Add(Teacher teacher)
        {
            this.teachers.Add(teacher);
            this.teachers.Save();
            return teacher;
        }

        public IQueryable<Teacher> All()
        {
            return this.teachers.All();
        }

        public void Delete(Teacher teacher)
        {
            this.teachers.Delete(teacher);
            this.teachers.Save();
        }

        public Teacher GetById(string id)
        {
            return this.teachers.GetById(id);
        }

        public void Save()
        {
            this.teachers.Save();
        }
    }
}
