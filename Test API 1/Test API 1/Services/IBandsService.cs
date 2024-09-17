using Test_API_1.DTOs;

namespace Test_API_1.Services
{
    public interface IBandsService
    { 
        public List<string> Errors { get; }
        Task<IEnumerable<BandDto>> Get();
        Task<BandDto> GetById(int id);
        Task<BandDto> Insert(BandInsertDto bandInsertDto);
        Task<BandDto> Update(BandUpdateDto bandUpdateDto, int id);
        Task<BandDto> Delete(int id);
        bool Validate(BandInsertDto bandInsertDto);
        bool Validate(BandUpdateDto bandUpdateDto);
    }
}
