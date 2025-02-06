using CodigoFacilito.UnitTesting.Api.Models.Results;

using MediatR;

namespace CodigoFacilito.UnitTesting.Api.UseCases.Products.GetAllProducts
{
    public record GetAllProductsRequest : IRequest<Result<GetAllProductsResponse>>;
}
