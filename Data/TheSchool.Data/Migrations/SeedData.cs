namespace TheSchool.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
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

            if (!context.Roles.Any(r => r.Name == GlobalConstants.TeacherRoleName))
            {
                AddTeachers(context);
            }

            if (!context.Disciplines.Any())
            {
                AddDisciplines(context);
            }

            if (!context.Divisions.Any())
            {
                AddDivisions(context);
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
                userManager.Create(teacher, teacher.Email);

                // Assign user to admin role
                userManager.AddToRole(teacher.Id, GlobalConstants.TeacherRoleName);
            }
        }

        private static void AddDisciplines(ApplicationDbContext context)
        {
            var math = new Discipline();
            math.Name = "Mathematics";
            context.Disciplines.Add(math);

            var english = new Discipline();
            english.Name = "English";
            context.Disciplines.Add(english);

            var gym = new Discipline();
            gym.Name = "Gymnastics";
            context.Disciplines.Add(gym);

            var music = new Discipline();
            music.Name = "Musics";
            context.Disciplines.Add(music);

        }

        private static void AddDivisions(ApplicationDbContext context)
        {
            var tutors = context.Teachers.ToList();

            // adding four classes from 1st to 4th grade
            for (int grade = 1; grade <= 4; grade++)
            {
                for (int index = 1; index <= 4; index++)
                {
                    var division = new Division();
                    division.ClassTutorId = tutors[((grade - 1) * 4) + index - 1].Id;
                    division.Grade = grade;
                    division.Name = GetDivisioName(grade, index);
                    division.Students = GetRandomStudents(context, random.Next(10, 20));
                    foreach (var discipline in context.Disciplines)
                    {
                        division.Disciplines.Add(discipline);
                    }

                    context.Divisions.Add(division);
                    context.SaveChanges();
                }
            }
        }

        private static string GetDivisioName(int grade, int index)
        {
            var name = string.Empty;
            switch (index)
            {
                case 1:
                    return name = $"First {grade}";
                case 2:
                    return name = $"Second {grade}";
                case 3:
                    return name = $"Third {grade}";
                case 4:
                    return name = $"Fourth {grade}";
                default:
                    return name = $"Unknown {grade}";
            }
        }

        private static ICollection<Student> GetRandomStudents(ApplicationDbContext context, int studentsCount)
        {
            var students = new List<Student>();
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
                userManager.Create(student, userName);
            }

            return students;
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
    }
}
