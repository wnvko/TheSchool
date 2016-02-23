namespace TheSchool.Web.ViewModels.News
{
    using System.ComponentModel.DataAnnotations;

    public class NewsInputModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
