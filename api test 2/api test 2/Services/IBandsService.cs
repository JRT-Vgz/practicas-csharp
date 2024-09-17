using api_test_2.DTOs;

namespace api_test_2.Services
{
    public interface IBandsService<T, TI, TU>
    {
        Task<IEnumerable<T>> Get();
        Task<T> GetById(int id);
        Task<T> Add(TI bandInsertDto);
        Task<T> Update(TU bandUpdateDto, int id);
        Task<T> Delete(int id);
    }
}
