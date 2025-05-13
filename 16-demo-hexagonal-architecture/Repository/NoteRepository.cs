
using DomainComponent.Entities;
using DomainComponent.SecondaryPorts;
using Microsoft.EntityFrameworkCore;
using RepositoryComponent.Models;

namespace RepositoryComponent
{
    public class NoteRepository : ICommonRepository<Note>
    {
        private readonly ItemsDBContext _dbContext;

        public NoteRepository(ItemsDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Note note)
        {
            var noteModel = new NoteModel()
            {
                ItemId = note.ItemId,
                Message = note.Message,
                CreatedDate = DateTime.Now
            };

            await _dbContext.NotesModel.AddAsync(noteModel);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Note>> GetAllAsync()
            => await _dbContext.NotesModel
                .Select(n => new Note(n.Id, n.ItemId, n.Message))
                .ToListAsync();
    }
}
