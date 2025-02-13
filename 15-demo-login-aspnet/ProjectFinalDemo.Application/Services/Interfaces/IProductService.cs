using ProjectFinalDemo.Application.Models.Products;
using ProjectFinalDemo.Domain.Entities;

namespace ProjectFinalDemo.Application.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponseModel>> GetAll();
        Task<ProductResponseModel> GetById(int id);
        Task Add(ProductRequestModel entity);
        Task Update(ProductRequestModel entity, int id);
        Task Delete(int id);
    }
}
