namespace TheSchool.Web.ViewModels.Marks
{
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using TheSchool.Data.Models;
    using TheSchool.Web.Infrastructure.Mapping;

    public class MarksViewModel : IMapFrom<Mark>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [UIHint("MarksDropDownList")]
        public int Value { get; set; }

        public string Student { get; set; }


        public string Discipline { get; set; }

        public string Teacher { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Mark, MarksViewModel>()
                .ForMember(x => x.Student, opt => opt.MapFrom(x => x.Student.FirstName + " " + x.Student.SecondName));

            configuration.CreateMap<Mark, MarksViewModel>()
                .ForMember(x => x.Teacher, opt => opt.MapFrom(x => x.Teacher.FirstName + " " + x.Teacher.SecondName));

            configuration.CreateMap<Mark, MarksViewModel>()
                .ForMember(x => x.Discipline, opt => opt.MapFrom(x => x.Discipline.Name));
        }
    }
}
