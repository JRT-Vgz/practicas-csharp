
namespace DesignPatternsMIO.DecoratorCoffeeShop.Condiments
{
    public class Whip : CondimentDecorator
    {
        private AbstractBeverage _beverage;

        public Whip(AbstractBeverage beverage)
        {
            _beverage = beverage;
        }

        public override string getDescription()
        {
            return $"{_beverage.getDescription()}, Whip";
        }

        public override double cost()
        {
            return _beverage.cost() + 0.10;
        }
    }
}
