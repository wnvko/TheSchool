﻿namespace TheSchool.Services.Data
{
    using System.Linq;
    using TheSchool.Data.Common;
    using TheSchool.Data.Models;

    public class StudentsService : IStudentsService
    {
        private readonly IDbRepositoryStringy<Student> students;

        public StudentsService(IDbRepositoryStringy<Student> students)
        {
            this.students = students;
        }

        public IQueryable<Student> All()
        {
            return this.students.All();
        }

        public IQueryable<Student> GetTopTenByMarks()
        {
            return this.students
                .All()
                .OrderByDescending(s => s.Marks.Average(m => m.Value))
                .Take(10);
        }
    }
}