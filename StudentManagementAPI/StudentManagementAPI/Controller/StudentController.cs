using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementAPI.Services;
using StudentManagementAPI.Models;

namespace StudentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;
        public StudentController(IStudentService service)   
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = _service.GetById(id);
            if (student == null)
                return NotFound();
            return Ok(student);
        }
        [HttpPost]
        public IActionResult Add([FromBody] Student student)
        {
            var created = _service.Add(student);
            return CreatedAtAction(nameof(GetById), new { id = created.USN }, created);
        }
    }
}
