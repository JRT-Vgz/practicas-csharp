
namespace DesignPattern._8_StatePattern
{
    public class DebtorCustomerState : IState
    {
        public void Action(CustomerContext customerContext, decimal amount)
        {
            Console.WriteLine($"No puedes comprar, eres un deudor.");
        }
    }
}
