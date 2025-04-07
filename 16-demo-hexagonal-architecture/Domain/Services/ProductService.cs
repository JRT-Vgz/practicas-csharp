
using Domain.Entities;
using Domain.Ports.Primary;
using Domain.Ports.Secondary;

namespace Domain.Services
{
    public class ProductService : IService
    {
        private readonly IRepository _repository;

        public ProductService(IRepository repository)
        {
            _repository = repository;
        }

        public void Register(string name, decimal price)
        {
            var product = new Product(Guid.NewGuid(), name, price);
            _repository.Save(product);
        }

        public IEnumerable<Product> GetAll()
            => _repository.GetAll();
    }
}
