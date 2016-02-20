namespace TheSchool.Data.Common
{
    using TheSchool.Data.Common.Models;

    public interface IDbRepositoryInty<T> : IDbRepository<T, int>
    where T : class, IAuditInfo, IDeletableEntity, IIDableEntity<int>
    {
    }
}
