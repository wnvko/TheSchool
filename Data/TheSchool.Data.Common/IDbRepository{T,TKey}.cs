namespace TheSchool.Data.Common
{
    using System.Linq;
    using TheSchool.Data.Common.Models;

    public interface IDbRepository<T, in TKey>
        where T : class, IAuditInfo, IDeletableEntity, IIDableEntity<TKey>
    {
        IQueryable<T> All();

        IQueryable<T> AllWithDeleted();

        T GetById(TKey id);

        void Add(T entity);

        void Delete(T entity);

        void HardDelete(T entity);

        void Save();
    }
}
