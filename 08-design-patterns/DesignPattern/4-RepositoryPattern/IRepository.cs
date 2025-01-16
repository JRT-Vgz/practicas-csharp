
namespace DesignPattern._4_RepositoryPattern
{
    public interface IRepository<TEntity>
    {
        IEnumerable<TEntity> Get();
        TEntity Get(int id);
        void Add(TEntity entity);
        void Delete(int id);
        void Update(TEntity entity);
        void Save();
    }
}
