namespace TheSchool.Data.Models
{
    using System.Collections.Generic;
    using TheSchool.Data.Common.Models;

    public class News : BaseModel<int>
    {
        private ICollection<Vote> votes;

        public News()
        {
            this.votes = new HashSet<Vote>();
        }

        public string Title { get; set; }

        public string Content { get; set; }

        public string AuthorId { get; set; }

        public Teacher Author { get; set; }

        public virtual ICollection<Vote> Votes
        {
            get { return this.votes; }
            set { this.votes = value; }
        }
    }
}
