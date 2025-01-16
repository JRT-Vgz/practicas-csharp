
namespace DesignPattern._8_StatePattern
{
    public class NewCustomerState : IState
    {
        public void Action(CustomerContext customerContext, decimal amount)
        {
            Console.WriteLine($"Se le pone dinero a su saldo {amount}.");
            customerContext.Residue = amount;

            customerContext.SetState(new NotDebtorCustomerState());
        }
    }
}
