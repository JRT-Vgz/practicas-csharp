using Test_api_3.Models;

namespace Test_api_3.Services
{
    public interface ICommonService<TDto, TDtoInsert, TDtoUpdate>
    {
        Task<IEnumerable<TDto>> GetAll();
        Task<TDto> GetById(int id);
        Task<TDto> Add(TDtoInsert dtoInsert);
        Task<TDto> Update(TDtoUpdate dtoUpdate, int id);
        Task<TDto> Delete(int id);
    }
}
