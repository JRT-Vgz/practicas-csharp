
namespace DesignPattern._7_BuilderPattern
{
    public interface IBuilder
    {
        public void Reset();
        public void SetMilk(int milk);
        public void SetWater(int water);
        public void SetAlcohol(decimal alcohol);
        public void AddIngredients(string ingredient);
        public void Mix();
        public void Rest(int time);
    }
}
