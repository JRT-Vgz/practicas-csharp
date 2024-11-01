using Demo_REST_API.DTOs;
using Demo_REST_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo_REST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private IPostsService _postsService;

        public PostsController(IPostsService postsService) 
        {
            _postsService = postsService;
        }

        [HttpGet]
        public async Task<IEnumerable<PostDto>> Get() => await _postsService.Get();
    }


}
