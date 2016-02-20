namespace TheSchool.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using TheSchool.Common;

    public static class SeedData
    {
        private static Random random = new Random();

        public static void Seed(ApplicationDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == GlobalConstants.AdministratorRoleName))
            {
                AddAdministrator(context);
            }

            if (!context.Disciplines.Any())
            {
                AddDisciplines(context);
            }

            if (!context.Roles.Any(r => r.Name == GlobalConstants.TeacherRoleName))
            {
                AddTeachers(context);
            }
            if (!context.Divisions.Any())
            {
                AddDivisions(context);
            }

            if (!context.Users.Any(u => u.Roles.Count == 0))
            {
                AddRandomStudents(context, 320);
            }

            if (!context.Teachers.Any(t => t.Divisions.Count > 0))
            {
                AddTutorsToDivisions(context);
            }

            if (!context.Marks.Any())
            {
                AddMarks(context);
            }
        }

        private static void AddAdministrator(ApplicationDbContext context)
        {
            // Create admin role for the school director
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var role = new IdentityRole { Name = GlobalConstants.AdministratorRoleName };
            roleManager.Create(role);

            // Create admin user - the director
            var administratorUserName = GlobalConstants.DirectorEmail;
            var administratorPassword = GlobalConstants.DirectorPassword;
            var firstName = GetRandomFirstName(true);
            var lastName = GetRandomLastName(true);

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            var user = new Teacher
            {
                UserName = administratorUserName,
                Email = administratorUserName,
                FirstName = firstName,
                SecondName = lastName,
            };
            userManager.Create(user, administratorPassword);

            // Assign user to admin role
            userManager.AddToRole(user.Id, GlobalConstants.AdministratorRoleName);
        }

        private static void AddTeachers(ApplicationDbContext context)
        {
            // Create teacher role for the school teachers
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var role = new IdentityRole { Name = GlobalConstants.TeacherRoleName };
            roleManager.Create(role);

            // Create 16 teachers, a tutor for each class planned
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            var disciplines = context.Disciplines.ToList();
            for (int i = 0; i < 16; i++)
            {
                string firstName = string.Empty;
                string lastName = string.Empty;
                string userName = string.Empty;
                do
                {
                    var female = random.Next(2) < 1;
                    firstName = GetRandomFirstName(female);
                    lastName = GetRandomLastName(female);
                    userName = $"{firstName}.{lastName}@theschool.com";

                } while (context.Users.Any(t => t.UserName == userName));

                var teacher = new Teacher
                {
                    UserName = userName,
                    Email = userName,
                    FirstName = firstName,
                    SecondName = lastName,
                };
                teacher.Disciplines.Add(disciplines[random.Next(disciplines.Count)]);
                userManager.Create(teacher, teacher.Email);

                // Assign user to admin role
                userManager.AddToRole(teacher.Id, GlobalConstants.TeacherRoleName);
            }
        }

        private static void AddDisciplines(ApplicationDbContext context)
        {
            var math = new Discipline();
            math.Name = "Mathematics";
            context.Disciplines.AddOrUpdate(math);

            var english = new Discipline();
            english.Name = "English";
            context.Disciplines.AddOrUpdate(english);

            var gym = new Discipline();
            gym.Name = "Gymnastics";
            context.Disciplines.AddOrUpdate(gym);

            var music = new Discipline();
            music.Name = "Musics";
            context.Disciplines.AddOrUpdate(music);

            context.SaveChanges();
        }

        private static void AddDivisions(ApplicationDbContext context)
        {
            // adding four classes from 1st to 4th grade
            var disciplines = context.Disciplines.ToList();
            for (int grade = 1; grade <= 4; grade++)
            {
                for (int index = 1; index <= 4; index++)
                {
                    var division = new Division();

                    division.Grade = grade;
                    division.Name = GetDivisioName(grade, index);
                    foreach (var discipline in disciplines)
                    {
                        division.Disciplines.Add(discipline);
                    }

                    context.Divisions.AddOrUpdate(division);
                    context.SaveChanges();
                }
            }
        }

        private static string GetDivisioName(int grade, int index)
        {
            var indexAsString = string.Empty;
            switch (index)
            {
                case 1:
                    indexAsString = "A";
                    break;
                case 2:
                    indexAsString = "B";
                    break;
                case 3:
                    indexAsString = "C";
                    break;
                case 4:
                    indexAsString = "D";
                    break;
                default:
                    indexAsString = "No Such Index";
                    break;
            }

            var name = string.Empty;
            switch (grade)
            {
                case 1:
                    return name = $"First {indexAsString}";
                case 2:
                    return name = $"Second {indexAsString}";
                case 3:
                    return name = $"Third {indexAsString}";
                case 4:
                    return name = $"Fourth {indexAsString}";
                default:
                    return name = $"Unknown {indexAsString}";
            }
        }

        private static void AddRandomStudents(ApplicationDbContext context, int studentsCount)
        {
            var divisions = context.Divisions.ToList();
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            for (int index = 0; index < studentsCount; index++)
            {
                var student = new Student();

                string firstName = string.Empty;
                string secondName = string.Empty;
                string userName = string.Empty;
                do
                {
                    var female = random.Next(2) < 1;
                    firstName = GetRandomFirstName(female);
                    secondName = GetRandomLastName(female);
                    userName = $"{firstName}.{secondName}@theschool.com";

                } while (context.Users.Any(t => t.UserName == userName));


                student.FirstName = firstName;
                student.SecondName = secondName;
                student.Email = userName;
                student.UserName = userName;
                student.DivisionId = divisions[random.Next(divisions.Count)].Id;
                userManager.Create(student, userName);
            }
        }

        private static string GetRandomFirstName(bool female)
        {
            var maleNames = new string[] { "Alben", "Adrian", "Andrey", "Biser", "Boris", "Vasil", "Venko", "Georgi", "Gospodin", "Darin", "Dobrin", "Desislav", "Evgeniy", "Emil", "Zlatko", "Ivo", "Ivan", "Ivelin", "Krum", "Kubrat", "Kalin", "Marin", "Milko", "Nikola", "Nikifor", "Orlin", "Petar", "Plamen", "Rosen", "Rumen", "Stefan", "Spartak", "Teodor", "Tihomir", "Filip", "Hristo" };
            var femaleNames = new string[] { "Albena", "Adriana", "Andrea", "Bisera", "Borislava", "Vasilka", "Venko", "Gergana", "Gabriela", "Darina", "Dobrinka", "Desislava", "Elena", "Eleonora", "Zlatka", "Ivayla", "Ivelina", "Ivanka", "Krasimira", "Kalina", "Kristina", "Marina", "Milkana", "Nikolina", "Nadiya", "Olga", "Petya", "Plamena", "Ralitza", "Rumenena", "Stefka", "Sabina", "Teodora", "Tihomira", "Filipa", "Hristina" };

            if (female)
            {
                return femaleNames[random.Next(femaleNames.Length)];
            }
            else
            {
                return maleNames[random.Next(maleNames.Length)];
            }
        }

        private static string GetRandomLastName(bool female)
        {
            var secondNames = new string[] { "Albenov", "Adrianov", "Biserov", "Borisov", "Vasilev", "Venkov", "Georgiev", "Gospodinov", "Darinov", "Dobrinov", "Evgeniev", "Emilov", "Zlatkov", "Ivov", "Ivanov", "Krumov", "Kubratov", "Marinov", "Milkov", "Nikolaev", "Nikiforov", "Orlinov", "Petrov", "Plamenov", "Rosenov", "Rumenov", "Stefanov", "Spartakov", "Teodorov", "Tihomirov", "Filipov", "Hristov" };
            var randomSecondName = secondNames[random.Next(secondNames.Length)];

            if (female)
            {
                return randomSecondName + "a";
            }
            else
            {
                return randomSecondName;
            }
        }

        private static void AddTutorsToDivisions(ApplicationDbContext context)
        {
            var tutors = context.Teachers.ToList();
            var divisions = context.Divisions.ToList();
            var index = 1;
            foreach (var division in divisions)
            {
                tutors[index].Divisions.Add(division);
                index++;
                context.SaveChanges();
            }
        }

        private static void AddMarks(ApplicationDbContext context)
        {
            var students = context.Students.ToList();
            var disciplines = context.Disciplines.ToList();
            var teachersPerDiscipline = new Dictionary<int, List<string>>();
            foreach (var discipline in disciplines)
            {
                teachersPerDiscipline[discipline.Id] = discipline.Teachers.Select(t => t.Id).ToList();
            }

            var counter = 0;
            foreach (var student in students)
            {
                foreach (var discipline in disciplines)
                {
                    for (int index = 0; index < 3; index++)
                    {
                        var mark = new Mark();
                        mark.TeacherId = teachersPerDiscipline[discipline.Id][random.Next(teachersPerDiscipline[discipline.Id].Count)]; //discipline.Teachers.FirstOrDefault().Id;
                        mark.DisciplineId = discipline.Id;
                        mark.StudentId = student.Id;
                        mark.Value = random.Next(1, 7);
                        context.Marks.AddOrUpdate(mark);
                        counter++;
                        if (counter % 100 == 0)
                        {
                            context.SaveChanges();
                        }
                    }
                }
            }

            context.SaveChanges();
        }
    }
}
