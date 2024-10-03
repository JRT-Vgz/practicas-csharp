using _1_EnterpriseLayer;

namespace _2_ApplicationLayer
{
    public class GetBeerUseCase<TEntity, TOutput>
    {
        private readonly IRepository<TEntity> _beerRepository;
        private readonly IPresenter<TEntity, TOutput> _presenter;

        public GetBeerUseCase(IRepository<TEntity> beerRepository,
            IPresenter<TEntity, TOutput> presenter)
        {
            _beerRepository = beerRepository;
            _presenter = presenter;
        }


        public async Task<IEnumerable<TOutput>> GetAllAsync()
        {
            var beers = await _beerRepository.GetAllAsync();
            return _presenter.Present(beers);
        }
    }

}
