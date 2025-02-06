using CodigoFacilito.UnitTesting.Api.Data;
using CodigoFacilito.UnitTesting.Api.Entities;
using CodigoFacilito.UnitTesting.Api.Models.Results;
using CodigoFacilito.UnitTesting.Api.Repositories;

using MediatR;

namespace CodigoFacilito.UnitTesting.Api.UseCases.Products.CreateProduct
{
    public class CreateProductRequestHandler : IRequestHandler<CreateProductRequest, Result<CreateProductResponse>>
    {

        private readonly IProductRepository _repository;

        public CreateProductRequestHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<CreateProductResponse>> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                return "Debe ingresar un nombre.";
            }

            if (string.IsNullOrWhiteSpace(request.Description))
            {
                return "Debe ingresar una descripción.";
            }


            Product product = new()
            {
                Name = request.Name,
                Description = request.Description,
            };

            await _repository.AddProductAsync(product);


            CreateProductResponse response = new(product.Id,product.Name,product.Description);


            return response;
        }
    }
}
