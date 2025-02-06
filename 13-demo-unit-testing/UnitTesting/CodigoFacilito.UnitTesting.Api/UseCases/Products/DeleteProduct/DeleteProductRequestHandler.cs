using CodigoFacilito.UnitTesting.Api.Models.Results;
using CodigoFacilito.UnitTesting.Api.Repositories;

using MediatR;

namespace CodigoFacilito.UnitTesting.Api.UseCases.Products.DeleteProduct
{
    public class DeleteProductRequestHandler : IRequestHandler<DeleteProductRequest, Result>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductRequestHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Result> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductByIdAsync(request.Id);

            if (product is null)
            {
                return "No existe el producto";
            }

            await _productRepository.DeleteProductAsync(request.Id);


            return Result.Success;
        }
    }
}
