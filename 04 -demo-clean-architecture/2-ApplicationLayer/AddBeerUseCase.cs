using _1_EnterpriseLayer;
using _2_ApplicationLayer.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_ApplicationLayer
{
    public class AddBeerUseCase<TDto>
    {
        private readonly IRepository<Beer> _beerRepository;
        private readonly IMapper<TDto, Beer> _mapper;

        public AddBeerUseCase(IRepository<Beer> beerRepository,
            IMapper<TDto, Beer> mapper)
        {
            _beerRepository = beerRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(TDto dto)
        {
            var beer = _mapper.Map(dto);

            if (string.IsNullOrEmpty(beer.Name)) throw new ValidationException("El nombre de la cerveza es obligatorio.");

            await _beerRepository.AddAsync(beer);
        }
    }
}
