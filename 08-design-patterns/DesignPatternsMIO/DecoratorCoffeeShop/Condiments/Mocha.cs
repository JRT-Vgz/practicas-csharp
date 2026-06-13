
namespace DesignPatternsMIO.DecoratorCoffeeShop.Condiments
{
    public class Mocha : CondimentDecorator
    {
        private AbstractBeverage _beverage;

        public Mocha(AbstractBeverage beverage)
        {
            _beverage = beverage;
        }

        public override string getDescription()
        {
            return $"{_beverage.getDescription()}, Mocha"; 
        }

        public override double cost()
        {
            return _beverage.cost() + 0.20;
        }
    }
}
