using _1_EnterpriseLayer;
using _2_ApplicationLayer;
using _3_InterfaceAdapters_Adapters.Dtos;

namespace _3_InterfaceAdapters_Adapters
{
    public class PostExternalServiceAdapter : IExternalServiceAdapter<Post>
    {
        private readonly IExternalService<PostServiceDto> _externalService;
        public PostExternalServiceAdapter(IExternalService<PostServiceDto> externalService)
        {
            _externalService = externalService;
        }
        public async Task<IEnumerable<Post>> GetExternalDataAsync()
        {
            var postsES = await _externalService.GetServicesAsync();
            return postsES.Select(p => new Post
            {
                Id = p.Id,
                Title = p.Title,
                Body = p.Body
            });
        }
    }
}
