namespace ProjectFinalDemo.Domain.Entities
{
    public class ProductEntity : BaseEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public virtual CategoryEntity Category { get; set; } = new CategoryEntity();
        public int CategoryId { get; set; }
    }
}