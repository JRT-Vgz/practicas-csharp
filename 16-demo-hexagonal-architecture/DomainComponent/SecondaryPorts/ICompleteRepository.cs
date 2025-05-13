
namespace DomainComponent.SecondaryPorts
{
    public interface ICompleteRepository
    {
        Task Complete(int id);
    }
}
