using Demo_REST_API.DTOs;

namespace Demo_REST_API.Services
{
    public interface IPostsService
    {
        public Task<IEnumerable<PostDto>> Get();
    }
}
