namespace csharp_api_demo_bands.Services
{
    public interface ICommonService<TDto, TInsertDto, TUpdateDto>
    {
        Task<IEnumerable<TDto>> GetAll();
        Task<TDto> GetById(int id);
        Task<TDto> Insert(TInsertDto insertDto);
        Task<TDto> Update(TUpdateDto updateDto, int id);
        Task<TDto> Delete(int id);
    }
}
