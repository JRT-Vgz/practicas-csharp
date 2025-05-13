
using ApplicationComponent.DTOs;
using DomainComponent.SecondaryPorts;

namespace ApplicationComponent
{
    public class NoteDTOService : ICommonService<NoteDTO>
    {
        private readonly ICommonRepository<NoteDTO> _repository;

        public NoteDTOService(ICommonRepository<NoteDTO> repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(NoteDTO noteDTO)
        {
            await _repository.AddAsync(noteDTO);
        }

        public async Task<IEnumerable<NoteDTO>> GetAsync()
            => await _repository.GetAllAsync();
    }
}

