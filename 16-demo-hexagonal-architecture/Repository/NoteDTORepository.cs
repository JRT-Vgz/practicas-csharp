
using ApplicationComponent.DTOs;
using DomainComponent.Entities;
using DomainComponent.SecondaryPorts;
using Microsoft.EntityFrameworkCore;
using RepositoryComponent.Models;

namespace RepositoryComponent
{
    public class NoteDTORepository : ICommonRepository<NoteDTO>
    {
        private readonly ItemsDBContext _dbContext;

        public NoteDTORepository(ItemsDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(NoteDTO noteDTO)
        {
            var noteModel = new NoteModel()
            {
                ItemId = noteDTO.ItemId,
                Message = noteDTO.Message,
                Color = noteDTO.Color,
                CreatedDate = DateTime.Now
            };

            await _dbContext.NotesModel.AddAsync(noteModel);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<NoteDTO>> GetAllAsync()
            => await _dbContext.NotesModel
                .Select(n => new NoteDTO
                {
                    Id = n.Id,
                    ItemId = n.ItemId,
                    Message = n.Message,
                    Color = n.Color
                }).ToListAsync();

    }
}
