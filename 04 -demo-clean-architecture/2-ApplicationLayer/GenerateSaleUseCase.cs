using _1_EnterpriseLayer;
using _2_ApplicationLayer.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_ApplicationLayer
{
    public class GenerateSaleUseCase<TDto>
    {
        private IRepository<Sale> _repository;
        private readonly IMapper<TDto, Sale> _mapper;
        public GenerateSaleUseCase(IRepository<Sale> repository, IMapper<TDto, Sale> mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task ExecuteAsync(TDto saleDto)
        {
            var sale =  _mapper.Map(saleDto);
            
            // Reglas de negocio
            if (sale.Concepts.Count == 0)
                throw new ValidationException("Una venta debe tener conceptos.");

            if (sale.Total <= 0)
                throw new ValidationException("Una venta debe tener más de $ 0.00 en Total.");

            await _repository.AddAsync(sale);
        }
    }
}
