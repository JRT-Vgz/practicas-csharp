
namespace DesignPattern._6_StrategyPattern
{
    public class CarStrategy : IStrategy
    {
        public void Run()
        {
            Console.WriteLine("Soy un coche y me muevo con 4 ruedas.");
        }
    }
}
