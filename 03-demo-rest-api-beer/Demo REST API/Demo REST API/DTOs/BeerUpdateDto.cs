namespace Demo_REST_API.DTOs
{
    public class BeerUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Alcohol { get; set; }
        public int BrandID { get; set; }
    }
}
