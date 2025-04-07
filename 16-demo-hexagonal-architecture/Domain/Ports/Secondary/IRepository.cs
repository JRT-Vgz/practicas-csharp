
using Domain.Entities;

namespace Domain.Ports.Secondary
{
    public interface IRepository
    {
        void Save(Product product);
        List<Product> GetAll();
    }
}
