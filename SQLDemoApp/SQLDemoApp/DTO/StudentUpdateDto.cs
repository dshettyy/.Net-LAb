using System.ComponentModel.DataAnnotations;

namespace SQLDemo.App.DTOs
{
    public class StudentUpdateDto
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Department { get; set; }
    }
}