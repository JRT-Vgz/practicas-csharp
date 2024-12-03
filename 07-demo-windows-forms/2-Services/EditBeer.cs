
using _1_Entities;
using _2_Services.DTOs;

namespace _2_Services
{
    public class EditBeer<TAdditionalData>
    {
        private readonly IRepositoryAdditionalData<Beer, TAdditionalData> _repository;
        public readonly IMapper<BeerDTO, Beer> _mapperEntity;
        public readonly IMapper<BeerDTO, TAdditionalData> _mapperAdditionalData;
        public EditBeer(IRepositoryAdditionalData<Beer, TAdditionalData> repository,
        IMapper<BeerDTO, Beer> mapperEntity,
        IMapper<BeerDTO, TAdditionalData> mapperAdditionalData)
        {
            _repository = repository;
            _mapperEntity = mapperEntity;
            _mapperAdditionalData = mapperAdditionalData;
        }

        public async Task ExecuteAsync(BeerDTO beerDto)
        {
            var beer = _mapperEntity.Map(beerDto);
            var beerAdditionalData = _mapperAdditionalData.Map(beerDto);

            if (string.IsNullOrEmpty(beer.Name))
            {
                throw new Exception("El nombre de la cerveza es obligatorio.");
            }
            Console.WriteLine(beer.Id);
            if ((await _repository.GetByIdAsync(beer.Id)).Item1 == null)
            {
                throw new Exception("La cerveza no existe.");
            }

            await _repository.EditAsync(beer, beerAdditionalData);
        }
    }
}
