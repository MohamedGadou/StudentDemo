using Microsoft.AspNetCore.Mvc;
using StudentDemo.Domain.IService;
using StudentDemo.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // POST api/<StudentsController>
        [HttpPost]
        public async Task Post([FromBody] CreateUpdateStudentModel createUpdateStudentModel)
        {
            await _studentService.CreateAsync(createUpdateStudentModel.Name, HttpContext.Session.Id);
        }

    }
}
