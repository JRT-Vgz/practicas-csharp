
using Demo_REST_API.Controllers;

namespace Demo_REST_API.Services
{
    public class PeopleService : IPeopleService
    {
        public bool Validate(People people)
        {
            if (string.IsNullOrEmpty(people.Name))
            {
                return false;
            }
            return true;
        }
    }
}
