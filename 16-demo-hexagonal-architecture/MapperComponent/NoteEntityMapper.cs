using ApplicationComponent;
using ApplicationComponent.DTOs;
using DomainComponent.Entities;

namespace MapperComponent
{
    public class NoteEntityMapper : IMapper<NoteDTO, Note>
    {
        public Note Map(NoteDTO data)
        {
            return new Note(data.Id, data.ItemId, data.Message);
        }
    }
}
