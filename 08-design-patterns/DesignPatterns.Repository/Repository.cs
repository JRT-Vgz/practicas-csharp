
using DesignPatterns.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace DesignPatterns.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DesignPatternsContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public Repository(DesignPatternsContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public void Add(TEntity entity)
            => _dbSet.Add(entity);

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
        }

        public IEnumerable<TEntity> Get()
            => _dbSet.ToList();

        public TEntity Get(int id)
            => _dbSet.Find();

        public void Save()
            => _context.SaveChanges();

        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
