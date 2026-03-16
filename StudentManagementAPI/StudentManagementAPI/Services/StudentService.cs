using StudentManagementAPI.Models;
using System.Linq;
using System.Collections.Generic;

namespace StudentManagementAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly List<Student> _students = new();
        private int _nextUsn = 1;

        public List<Student> GetAll() => _students;
        public Student? GetById(int usn) => _students.FirstOrDefault(s => s.USN == usn);

        public Student Add(Student student)
        {
            student.USN = _nextUsn++;
            _students.Add(student);
            return student;
        }

        public bool Update(int usn, Student updatedStudent)
        {
            var existingStudent = GetById(usn);
            if (existingStudent == null)
                return false;
            existingStudent.Name = updatedStudent.Name;
            existingStudent.Age = updatedStudent.Age;
            existingStudent.Course = updatedStudent.Course;
            return true;
        }

        public bool Delete(int usn)
        {
            var student = GetById(usn);
            if (student == null)
                return false;
            _students.Remove(student);
            return true;
        }
    }
}
