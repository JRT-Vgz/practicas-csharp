
using DesignPattern._4_RepositoryPattern;
using DesignPattern.Models;

namespace DesignPattern._5_UnitOfWork
{
    public interface IUnitOfWork
    {
        public IRepository<Beer> Beers { get; }
        public IRepository<Brand> Brands { get; }

        public void Save();
    }
}
