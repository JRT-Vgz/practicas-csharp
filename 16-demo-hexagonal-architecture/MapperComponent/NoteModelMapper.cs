
using ApplicationComponent.DTOs;
using ApplicationComponent;
using RepositoryComponent.Models;

namespace MapperComponent
{
    public class NoteModelMapper : IMapper<NoteDTO, NoteModel>
    {
        public NoteModel Map(NoteDTO data)
        {
            return new NoteModel()
            {
                Id = data.Id,
                ItemId = data.ItemId,
                Message = data.Message,
                Color = data.Color,
                CreatedDate = DateTime.Now
            };
        }
    }
}
