
namespace DomainComponent.SecondaryPorts
{
    public interface IRepositoryFactory<TRepository, TExtraData>
    {
        TRepository Create(TExtraData extraData);
    }
}
