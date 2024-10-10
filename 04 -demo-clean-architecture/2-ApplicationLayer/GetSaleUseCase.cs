using _1_EnterpriseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_ApplicationLayer
{
    public class GetSaleUseCase
    {
        private readonly IRepository<Sale> _saleRepository;
        public GetSaleUseCase(IRepository<Sale> saleRepository)
        => _saleRepository = saleRepository;



        public async Task<IEnumerable<Sale>> ExecuteAsync() 
            => await _saleRepository.GetAllAsync();
    }
}
