using csharp_api_demo_bands.DTOs;
using System.Configuration;

namespace csharp_api_demo_bands.Services
{
    public interface ICommonServiceValidate<TInsertDto, TUpdateDto>
    {
        public List<string> Errors { get; }
        Task<bool> Validate(TInsertDto inserDto);
        Task<bool> Validate(TUpdateDto updateDto);
    }
}
