
using DomainComponent.Entities;
using DomainComponent.SecondaryPorts;
using RepositoryComponent.ExtraData;
using RepositoryComponent.Models;
using System.Linq.Expressions;

namespace RepositoryComponent
{
    public class NoteFactoriedRepository : IAddRepository<Note>
    {
        private readonly ItemsDBContext _context;
        private NoteExtraData _extraData;

        public NoteFactoriedRepository(ItemsDBContext context,
            NoteExtraData extraData)
        {
            _context = context;
            _extraData = extraData;
        }

        public async Task AddAsync(Note note)
        {
            var noteModel = new NoteModel()
            {
                Message = note.Message,
                ItemId = note.ItemId,
                CreatedDate = DateTime.Now,
                Color = _extraData.Color
            };

            await _context.NotesModel.AddAsync(noteModel);
            await _context.SaveChangesAsync();
        }
    }
}
