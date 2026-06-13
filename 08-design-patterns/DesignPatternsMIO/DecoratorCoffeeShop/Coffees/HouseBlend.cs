
namespace DesignPatternsMIO.DecoratorCoffeeShop.Coffees
{
    public class HouseBlend : AbstractBeverage
    {
        public HouseBlend()
        {
            _description = "House Blend";
        }

        public override double cost()
        {
            return 0.89;
        }
    }
}
