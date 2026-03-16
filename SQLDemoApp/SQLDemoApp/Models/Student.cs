using System.ComponentModel.DataAnnotations;

namespace SQLDemo.App.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string Usn { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public string Department { get; set; } = string.Empty;
    }
}