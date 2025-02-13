namespace ProjectFinalDemo.Domain.Entities
{
    public class RoleEntity : BaseEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }

        public ICollection<UserEntity> Users { get; set; }
    }
}
