
namespace _1_Entities
{
    public class Beer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
        public decimal Alcohol { get; set; }
        public bool IsStrongBeer() => Alcohol > 7.5m;
    }
}
