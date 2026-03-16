using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLDemo.App.Data;
using SQLDemo.App.DTOs;
using SQLDemo.App.Models;

namespace SQLDemo.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentReadDto>>> GetAll()
        {
            var students = await _context.Students
                .Select(s => new StudentReadDto
                {
                    Id = s.Id,
                    FullName = s.FullName,
                    Email = s.Email,
                    Department = s.Department
                })
                .ToListAsync();

            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentReadDto>> GetById(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
                return NotFound();

            var readDto = new StudentReadDto
            {
                Id = student.Id,
                //Usn = student.Usn,
                FullName = student.FullName,
                Email = student.Email,
                Department = student.Department
            };

            return Ok(readDto);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<StudentReadDto>> Create(StudentCreateDto dto)
        {
            var student = new Student
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Department = dto.Department
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            var readDto = new StudentReadDto
            {
                Id = student.Id,
                FullName = student.FullName,
                Email = student.Email,
                Department = student.Department
            };

            return CreatedAtAction(
                nameof(GetById),
                new { id = student.Id },
                readDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, StudentUpdateDto dto)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
                return NotFound();

            //student.Usn = dto.Usn;
            student.FullName = dto.FullName;
            student.Email = dto.Email;
            student.Department = dto.Department;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
                return NotFound();

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}