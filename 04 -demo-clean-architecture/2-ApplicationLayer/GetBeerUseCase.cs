using _1_EnterpriseLayer;

namespace _2_ApplicationLayer
{
    public class GetBeerUseCase<TModel>
    {
        private readonly IRepository<TModel> _beerRepository;

        public GetBeerUseCase(IRepository<TModel> beerRepository)
        {
            _beerRepository = beerRepository;
        }


        public async Task<IEnumerable<TModel>> GetAllAsync() =>
            await _beerRepository.GetAllAsync();
    }

}
