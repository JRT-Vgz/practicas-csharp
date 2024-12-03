
using _1_Entities;

namespace _2_Services
{
    public class EditBeer<TAdditionalData>
    {
        private readonly IRepositoryAdditionalData<Beer, TAdditionalData> _repository;
        public EditBeer(IRepositoryAdditionalData<Beer, TAdditionalData> repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(Beer beer)
        {
            if (string.IsNullOrEmpty(beer.Name))
            {
                throw new Exception("El nombre de la cerveza es obligatorio.");
            }
            Console.WriteLine(beer.Id);
            if (await _repository.GetByIdAsync(beer.Id) == null)
            {
                throw new Exception("La cerveza no existe.");
            }

            await _repository.EditAsync(beer);
        }
    }
}
