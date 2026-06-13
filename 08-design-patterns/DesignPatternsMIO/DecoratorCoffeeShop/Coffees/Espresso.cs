
namespace DesignPatternsMIO.DecoratorCoffeeShop.Coffees
{
    public class Espresso : AbstractBeverage
    {
        public Espresso()
        {
            _description = "Espresso";
        }

        public override double cost()
        {
            return 1.99;
        }
    }
}
