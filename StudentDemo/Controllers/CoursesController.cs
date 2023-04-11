using Microsoft.AspNetCore.Mvc;
using StudentDemo.Domain.IService;
using StudentDemo.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;
        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        // GET: api/<CoursesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CoursesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CoursesController>
        [HttpPost]
        public async Task<GetCourseDto> Post([FromBody] CreateUpdateCourseModel createUpdateCourseModel)
        {
            var res = await _courseService.CreateAsync(createUpdateCourseModel.Name, HttpContext.Session.Id);            

            return new GetCourseDto
            {
                Id = res.Id,
                Name = res.Name,
            };
        }
    }
}
