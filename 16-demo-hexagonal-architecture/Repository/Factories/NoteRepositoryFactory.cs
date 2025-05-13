
using DomainComponent.Entities;
using DomainComponent.SecondaryPorts;
using RepositoryComponent.ExtraData;

namespace RepositoryComponent.Factories
{
    public class NoteRepositoryFactory : IRepositoryFactory<IAddRepository<Note>, NoteExtraData>
    {
        private readonly ItemsDBContext _context;

        public NoteRepositoryFactory(ItemsDBContext context)
        {
            _context = context;
        }

        public IAddRepository<Note> Create(NoteExtraData extraData)
        {
            return new NoteFactoriedRepository(_context, extraData);
        }
    }
}
