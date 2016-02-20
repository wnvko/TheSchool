namespace TheSchool.Data.Common.Models
{
    public interface IIDableEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
