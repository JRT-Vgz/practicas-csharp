
using DomainComponent.SecondaryPorts;
using RepositoryComponent.Models;

namespace RepositoryComponent
{
    public class NoteMapperRepository : IAddRepository<NoteModel>
    {
        private readonly ItemsDBContext _context;

        public NoteMapperRepository(ItemsDBContext context)
        {
            _context = context;
        }

        public async Task AddAsync(NoteModel model)
        {
            _context.NotesModel.Add(model);
            await _context.SaveChangesAsync();
        }
    }
}
