using _1_EnterpriseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _2_ApplicationLayer
{
    public class GetSaleSearchUseCase<TModel>
    {
        private readonly IRepositorySearch<TModel, Sale> _repositorySearch;
        public GetSaleSearchUseCase(IRepositorySearch<TModel, Sale> repositorySearch)
        => _repositorySearch = repositorySearch;

        public async Task<IEnumerable<Sale>> ExecuteAsync(Expression<Func<TModel, bool>> predicate)
            => await _repositorySearch.GetAsync(predicate);
    }
}
