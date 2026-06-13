
namespace DesignPatternsMIO.DecoratorCoffeeShop.Condiments
{
    public class Soy : CondimentDecorator
    {
        private AbstractBeverage _beverage;

        public Soy(AbstractBeverage beverage)
        {
            _beverage = beverage;
        }

        public override string getDescription()
        {
            return $"{_beverage.getDescription()}, Soy";
        }

        public override double cost()
        {
            return _beverage.cost() + 0.15;
        }
    }
}
