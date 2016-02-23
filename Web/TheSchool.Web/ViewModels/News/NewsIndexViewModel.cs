namespace TheSchool.Web.ViewModels.News
{
    using System.Collections.Generic;

    public class NewsIndexViewModel
    {
        public ICollection<NewsViewModel> News { get; set; }

        public int Page { get; set; }

        public int Pages { get; set; }
    }
}
