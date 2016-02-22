namespace TheSchool.Data.Models
{
    using TheSchool.Data.Common.Models;

    public class Vote : BaseModel<int>
    {
        public string VoterId { get; set; }

        public virtual ApplicationUser Voter { get; set; }

        public int NewsId { get; set; }

        public virtual News News { get; set; }
    }
}
