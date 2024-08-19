using Microsoft.Extensions.Configuration.UserSecrets;

namespace Demo_REST_API.DTOs
{
    public class PostDto
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Body { get; set; }
    }
}
