using Demo_REST_API.Controllers;

namespace Demo_REST_API.Services
{
    public interface IPeopleService
    {
        bool Validate(People people);
    }
}
