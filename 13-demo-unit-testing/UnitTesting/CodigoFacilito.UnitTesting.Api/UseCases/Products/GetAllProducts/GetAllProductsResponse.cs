namespace CodigoFacilito.UnitTesting.Api.UseCases.Products.GetAllProducts
{

    public record ProductData(Guid Id, string Name, string Description);
    public record GetAllProductsResponse(IEnumerable<ProductData> Products);
}
