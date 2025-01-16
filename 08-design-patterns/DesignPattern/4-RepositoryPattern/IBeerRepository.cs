
using DesignPattern.Models;

namespace DesignPattern._4_RepositoryPattern
{
    public interface IBeerRepository
    {
        IEnumerable<Beer> Get();
        Beer Get(int id);
        void Add(Beer beer);
        void Delete(int id);
        void Update(Beer beer);
        void Save();
    }
}
