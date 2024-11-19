using _06_demo_basicauth_asp.Models;

namespace _06_demo_basicauth_asp.Services
{
    public interface IBeerService
    {
        public Task<List<Beer>> Get();
    }
}
