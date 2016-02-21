namespace TheSchool.Web.ViewModels.Students
{
    using System.Collections.Generic;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;
    using Marks;

    public class StudentViewModel : IMapFrom<Student>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string Division { get; set; }

        public virtual IList<MarksViewModel> Marks { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Student, StudentViewModel>()
                .ForMember(x => x.Division, opt => opt.MapFrom(x => x.Division.Name));
        }
    }
}