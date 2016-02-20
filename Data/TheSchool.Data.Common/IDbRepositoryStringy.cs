namespace TheSchool.Data.Common
{
    using TheSchool.Data.Common.Models;

    public interface IDbRepositoryStringy<T> : IDbRepository<T, string>
    where T : class, IAuditInfo, IDeletableEntity, IIDableEntity<string>
    {
    }
}
