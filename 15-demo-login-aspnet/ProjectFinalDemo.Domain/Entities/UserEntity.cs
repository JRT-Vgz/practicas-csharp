namespace ProjectFinalDemo.Domain.Entities
{
    public class UserEntity :BaseEntity
    {

        public int Id { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required string FullName { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }

        public int RoleId { get; set; }
        public RoleEntity? Role { get; set; }
    }
}
