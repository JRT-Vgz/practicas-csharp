using Demo_REST_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace Demo_REST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private IPeopleService _peopleService;

        public PeopleController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        [HttpGet("all")]
        public List<People> GetPeople() => Repository.People;

        [HttpGet("{id}")]
        public ActionResult<People> Get(int id)
        {
            var people = Repository.People.FirstOrDefault(x => x.Id == id);

            if (people == null) return NotFound();
            return Ok(people);
        }

        [HttpGet("search/{search}")]
        public List<People> Get(string search) => Repository.People.Where(p => p.Name.ToUpper().Contains(search.ToUpper())).ToList();

        [HttpPost]
        public IActionResult Add(People people)
        {
            if (!_peopleService.Validate(people)) return BadRequest();
            Repository.People.Add(people);
            return NoContent();
        }
    }




    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
    }

    public class Repository
    {
        public static List<People> People = new List<People>()
        {
            new People()
            {
                Id = 1,
                Name = "Pedro",
                Birthdate = new DateTime(1990,12,3)
            },
            new People()
            {
                Id = 2,
                Name = "Xaxi",
                Birthdate = new DateTime(1991,12,3)
            },
            new People()
            {
                Id = 3,
                Name = "Alex",
                Birthdate = new DateTime(1992,12,3)
            },
            new People()
            {
                Id = 4,
                Name = "Visent",
                Birthdate = new DateTime(1993,12,3)
            }
        };
    }
}
