
using System.Reflection.Metadata.Ecma335;

namespace DesignPatternsMIO.DecoratorCoffeeShop
{
    public abstract class AbstractBeverage
    {
        protected string _description;

        public virtual string getDescription()
        {
            return _description;
        }

        public abstract double cost();
    }
}
