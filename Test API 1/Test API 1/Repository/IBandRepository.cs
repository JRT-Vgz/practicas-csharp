using Test_API_1.Models;

namespace Test_API_1.Repository
{
    public interface IBandRepository
    {
        Task<IEnumerable<Band>> Get();
        Task<Band> GetById(int id);
        Task Insert(Band band);
        void Update(Band band);
        void Delete(Band band);
        Task Save();
    }
}
