using CodigoFacilito.UnitTesting.Api.Models.Results;
using CodigoFacilito.UnitTesting.Api.Repositories;

using MediatR;

namespace CodigoFacilito.UnitTesting.Api.UseCases.Products.GetAllProducts
{
    public class GetAllProductsRequestHandler : IRequestHandler<GetAllProductsRequest, Result<GetAllProductsResponse>>
    {
        private readonly IProductRepository _repository;

        public GetAllProductsRequestHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<GetAllProductsResponse>> Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
        {
            var products = await _repository.GetAllProductsAsync();

            var productsData = products.Select(p => new ProductData(p.Id, p.Name, p.Description));

            GetAllProductsResponse response = new(productsData);

            return response;
        }
    }
}
