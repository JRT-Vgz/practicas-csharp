
using Domain.Entities;

namespace Domain.Ports.Primary
{
    public interface IService
    {
        void Register(string name, decimal price);
        IEnumerable<Product> GetAll();
    }
}
