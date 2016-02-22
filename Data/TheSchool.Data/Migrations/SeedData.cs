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
        private static string loremIpsumString =
            "Duis nec est elit. Phasellus augue ante, imperdiet vel nibh vel, placerat semper urna. Integer urna est, accumsan at nulla in, scelerisque tempor lorem. Aliquam euismod non arcu pretium ultrices. Suspendisse ac ligula non nunc ullamcorper rutrum. Vestibulum vel eros in metus lacinia vulputate. Nunc sit amet enim eu felis tincidunt posuere nec a sem. Suspendisse augue mi, dignissim vel blandit gravida, bibendum quis eros. Donec semper vitae metus vel vulputate. Mauris vitae nisl pellentesque, aliquet erat quis, scelerisque velit. Nulla ac laoreet neque, a iaculis ex. Pellentesque a erat at sapien vestibulum dictum eu eu ipsum.\n" +
            "Maecenas luctus pretium arcu, non sagittis eros commodo vitae.Curabitur a nibh sed elit vehicula consequat vitae eu nisl.Morbi egestas ex sit amet dapibus venenatis.Nunc ultrices justo diam, vitae mollis mi rhoncus sed.Aliquam consectetur lobortis erat, at finibus tellus.Nunc ullamcorper imperdiet turpis vel aliquet. Quisque bibendum mattis ex vel fermentum.\n" +
            "Mauris posuere eros vitae elit consequat, nec hendrerit purus finibus. Nam rhoncus, ipsum a lacinia malesuada, ligula mi ornare neque, nec consectetur elit ante facilisis dolor. Duis vehicula at nisi vitae porta. In hac habitasse platea dictumst.Integer laoreet justo in interdum finibus. Mauris vitae vestibulum ex. Nam sollicitudin massa a orci efficitur, ac tristique sapien condimentum. Praesent vitae pulvinar leo. Aliquam placerat arcu non nisi dictum, ut efficitur lacus feugiat. Proin ut magna et sem accumsan tincidunt.Fusce interdum felis eros, sollicitudin laoreet est aliquet sit amet. Proin at fermentum metus, ut semper diam.Sed sed feugiat est. Integer sit amet consectetur lacus, quis tincidunt enim.Fusce in magna at ex ornare tempus a id nibh.\n" +
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Ut quis ullamcorper arcu, eget commodo ligula.Curabitur dapibus turpis sem, ullamcorper luctus lectus suscipit sit amet. Maecenas id viverra nunc, eu fermentum risus.Quisque egestas luctus nisi, vel euismod elit imperdiet porta.Nunc ut viverra nunc. Quisque convallis efficitur dolor, ac laoreet mauris posuere ut.Donec et venenatis neque. Aliquam erat volutpat.Donec et mauris vestibulum, pellentesque elit sit amet, ornare ante.\n" +
            "Etiam non quam in massa pellentesque dictum sed et diam. Nullam euismod faucibus velit, non eleifend massa mollis et.Nam sapien arcu, interdum vitae risus consectetur, lacinia tincidunt dolor.Curabitur aliquam ullamcorper lorem, a cursus nibh ornare ut.Nulla rhoncus nisl ut neque sollicitudin placerat.Vestibulum aliquet justo in tristique rutrum. Donec ut condimentum risus, sed tempus turpis.Sed a ipsum et ipsum maximus consectetur eu sit amet augue.Cras consequat nunc nec felis blandit, vitae feugiat odio dapibus. Mauris condimentum lorem et neque vehicula porttitor.Aenean pulvinar mauris sollicitudin semper ornare. Quisque malesuada, enim quis aliquam blandit, magna lectus pulvinar felis, sed posuere mi augue ac urna. Etiam iaculis, orci ac tempor commodo, dolor purus congue tellus, vitae accumsan ante mi eget nisi.\n" +
            "Aenean at tristique turpis. Praesent commodo odio ante, non suscipit tortor volutpat sit amet. Duis feugiat nisi ut iaculis aliquet. Cras vel ex ac orci vehicula tincidunt.Pellentesque interdum arcu at nibh aliquam mollis.Sed convallis purus ut auctor luctus. Morbi vel lacus nec ipsum iaculis pellentesque.Pellentesque nisi dolor, molestie sed odio lacinia, facilisis fringilla eros.Ut fringilla magna non imperdiet hendrerit. Suspendisse eget fringilla lectus, nec aliquam justo.Nunc in dolor tempus arcu tincidunt iaculis sed sit amet urna.Vivamus nec augue urna. Duis interdum sem sit amet ligula mollis, at maximus nisl facilisis. Aliquam quis velit nec mi dapibus scelerisque.Nulla dignissim elit ut neque faucibus venenatis.Nulla tempus condimentum vestibulum.\n" +
            "Suspendisse turpis velit, rhoncus vitae efficitur rhoncus, efficitur id ante.Maecenas sollicitudin, neque in vulputate tincidunt, nibh lacus mattis dolor, sit amet ultricies justo ante quis elit.Donec consectetur turpis nulla, ullamcorper volutpat erat lacinia sit amet. Quisque arcu ex, semper cursus pretium non, eleifend non quam.Proin ut sodales neque, nec ultrices dui.Maecenas vestibulum tellus id vestibulum bibendum. Sed aliquet elit vitae nunc vulputate, vel hendrerit urna sagittis. Donec eu consequat mauris, at facilisis ligula.Nunc elementum tristique lectus, in cursus est molestie id. Vestibulum viverra lacus vitae purus iaculis tincidunt.Sed porttitor dui in dui ullamcorper, eget tincidunt felis aliquet. Cras porta ornare arcu at aliquet. Donec porttitor consectetur magna id accumsan. In hac habitasse platea dictumst.\n" +
            "Praesent pharetra ante vitae odio volutpat maximus.Cras elementum et nisl sit amet maximus.Nulla cursus porta enim at eleifend. Duis lectus lectus, pretium non tellus sit amet, venenatis tincidunt risus.Duis semper ex id mi gravida, sit amet efficitur nulla pellentesque.Duis sit amet urna vitae est mattis tincidunt eget sit amet velit. Etiam ultrices nibh euismod sapien suscipit, ut lacinia urna pharetra. Cras est mi, vestibulum ac enim at, dignissim posuere nunc.\n" +
            "Phasellus porta laoreet ante, at blandit ex volutpat sit amet. Ut tincidunt tortor sit amet lobortis accumsan.Vivamus pharetra risus vitae sapien feugiat lobortis.Maecenas sollicitudin velit odio, molestie gravida mauris iaculis varius.Nullam in ultricies lacus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Suspendisse eget facilisis sem, in rhoncus ligula.Aliquam nec laoreet orci.\n" +
            "Aliquam erat tellus, efficitur at purus ac, maximus scelerisque libero.Nam massa massa, tincidunt id dictum accumsan, eleifend eget ex.Maecenas pretium, dui ut dignissim tristique, enim mauris condimentum libero, id pellentesque mauris ante non lectus. Mauris quis arcu a eros vehicula hendrerit eget nec felis. In condimentum magna facilisis laoreet faucibus. Praesent ut magna pellentesque, laoreet dolor ac, pretium urna. Etiam sed erat id turpis gravida finibus.";

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

            if (!context.Teachers.Any(t => t.IsTeacher == true))
            {
                MarkTeachers(context);
            }

            if (!context.News.Any())
            {
                AddNews(context);
            }

            if (!context.Votes.Any())
            {
                AddVotes(context);
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
                }
                while (context.Users.Any(t => t.UserName == userName));

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
                }
                while (context.Users.Any(t => t.UserName == userName));

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
                        mark.TeacherId = teachersPerDiscipline[discipline.Id][random.Next(teachersPerDiscipline[discipline.Id].Count)];
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

        private static void MarkTeachers(ApplicationDbContext context)
        {
            var teachers = context.Teachers.ToList();
            foreach (var teacher in teachers)
            {
                teacher.IsTeacher = true;
            }

            context.SaveChanges();

            var students = context.Students.ToList();
            foreach (var student in students)
            {
                student.IsTeacher = false;
            }

            context.SaveChanges();
        }

        private static void AddNews(ApplicationDbContext context)
        {
            var teachers = context.Teachers.ToList();
            var newsCount = 100;
            for (int index = 0; index < newsCount; index++)
            {
                var news = new News();
                news.Title = loremIpsumString.Substring(5, random.Next(25));
                news.Content = loremIpsumString.Substring(0, random.Next(5000));
                news.AuthorId = teachers[random.Next(teachers.Count)].Id;
                news.CreatedOn = DateTime.Now.AddDays(random.Next(-100, 100)).AddHours(random.Next(-12, 12));
                context.News.Add(news);
            }

            context.SaveChanges();
        }

        private static void AddVotes(ApplicationDbContext context)
        {
            var news = context.News.ToList();
            var users = context.Users.ToList();
            foreach (var novina in news)
            {
                var votes = random.Next(20);
                for (int index = 0; index < votes; index++)
                {
                    var vote = new Vote();
                    vote.NewsId = novina.Id;
                    vote.VoterId = users[random.Next(users.Count)].Id;
                    context.Votes.Add(vote);
                    novina.ModifiedOn = novina.CreatedOn;
                }

                context.SaveChanges();
            }

            context.SaveChanges();
        }
    }
}
