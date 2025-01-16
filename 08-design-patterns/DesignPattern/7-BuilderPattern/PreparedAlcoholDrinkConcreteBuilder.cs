
namespace DesignPattern._7_BuilderPattern
{
    public class PreparedAlcoholDrinkConcreteBuilder : IBuilder
    {
        private PreparedDrink _preparedDrink;
        public PreparedAlcoholDrinkConcreteBuilder()
        {
            Reset();
        }
        public void AddIngredients(string ingredient)
        {
            if(_preparedDrink.Ingredientes == null) { _preparedDrink.Ingredientes = new List<string>(); }

            _preparedDrink.Ingredientes.Add(ingredient);
        }

        public void Mix()
        {
            string ingredients = _preparedDrink.Ingredientes.Aggregate((i, j) => i + ", " + j);
            _preparedDrink.Result = $"Bebida preparada con {_preparedDrink.Alcohol} de alcohol y con los ingredientes {ingredients}";
            Console.WriteLine("Mezclamos los ingredientes.");
        }

        public void Reset()
        {
            _preparedDrink = new PreparedDrink();
        }

        public void Rest(int time)
        {
            Thread.Sleep(time);
            Console.WriteLine("Listo para beberse.");
        }

        public void SetAlcohol(decimal alcohol)
        {
            _preparedDrink.Alcohol = alcohol;
        }

        public void SetMilk(int milk)
        {
            _preparedDrink.Milk = milk;
        }

        public void SetWater(int water)
        {
            _preparedDrink.Water = water;
        }

        public PreparedDrink GetPreparedDrink() => _preparedDrink;
    }
}
