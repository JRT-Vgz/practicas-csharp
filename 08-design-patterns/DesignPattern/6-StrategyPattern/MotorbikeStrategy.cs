
namespace DesignPattern._6_StrategyPattern
{
    public class MotorbikeStrategy : IStrategy
    {
        public void Run()
        {
            Console.WriteLine("Soy una moto y me muevo con dos ruedas.");
        }
    }
}
