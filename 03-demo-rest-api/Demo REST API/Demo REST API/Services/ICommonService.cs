using Demo_REST_API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Demo_REST_API.Services
{
    public interface ICommonService<T, TI, TU>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Add(TI commonInsertDto);
        Task<T> Update(TU commonUpdateDto, int id);
        Task<T> Delete(int id);
    }
}
