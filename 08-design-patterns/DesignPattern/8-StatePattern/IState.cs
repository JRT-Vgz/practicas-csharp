
namespace DesignPattern._8_StatePattern
{
    public interface IState
    {
        public void Action(CustomerContext customerContext, decimal amount);
    }
}
