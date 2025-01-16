
namespace DesignPattern._3_DependencyInjection
{
    public class DrinkWithBeer
    {
        private Beer _beer;
        private decimal _water;
        private decimal _sugar;
        public DrinkWithBeer(Beer beer, decimal water, decimal sugar)
        {
            _beer = beer;
            _water = water;
            _sugar = sugar;
        }

        public void Build()
        {
            Console.WriteLine($"Preparamos bebida que tiene agua {_water}, azúcar {_sugar} y cerveza {_beer.Name}");
        }
    }
}
