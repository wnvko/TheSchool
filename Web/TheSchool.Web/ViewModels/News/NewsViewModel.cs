namespace TheSchool.Web.ViewModels.News
{
    using System;
    using System.Linq;
    using AutoMapper;
    using TheSchool.Data.Models;
    using TheSchool.Web.Infrastructure.Mapping;

    public class NewsViewModel : IMapFrom<News>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public DateTime CreatedOn { get; set; }

        public int Votes { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<News, NewsViewModel>()
                .ForMember(x => x.Author, opt => opt.MapFrom(x => x.Author.FirstName + " " + x.Author.SecondName))
                .ForMember(x => x.Votes, opt => opt.MapFrom(x => x.Votes.Count()));
        }
    }
}
