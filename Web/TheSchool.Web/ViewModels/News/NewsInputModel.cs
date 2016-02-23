using System.ComponentModel.DataAnnotations;

namespace TheSchool.Web.ViewModels.News
{
    public class NewsInputModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
