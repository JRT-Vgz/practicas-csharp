
namespace DesignPattern._8_StatePattern
{
    public class NotDebtorCustomerState : IState
    {
        public void Action(CustomerContext customerContext, decimal amount)
        {
            if (amount <= customerContext.Residue)
            {
                customerContext.Discount(amount);
                Console.WriteLine($"Solicitud permitida, gasta {amount} y le queda de saldo {customerContext.Residue}.");
                
                if (customerContext.Residue <= 0) { customerContext.SetState(new DebtorCustomerState()); }
            }
            else
            {
                Console.WriteLine($"Solicitud no permitida, ya que tienes {customerContext.Residue} y quieres gastar {amount}.");
            }

        }
    }
}
