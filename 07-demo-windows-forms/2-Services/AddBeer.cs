
using _1_Entities;

namespace _2_Services
{
    public class AddBeer
    {
        private readonly IRepository<Beer> _repository;
        public AddBeer(IRepository<Beer> repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(Beer beer)
        {
            if (string.IsNullOrEmpty(beer.Name))
            {
                throw new Exception("El nombre de la cerveza es obligatorio.");
            }

            await _repository.AddAsync(beer);
        }
    }
}
