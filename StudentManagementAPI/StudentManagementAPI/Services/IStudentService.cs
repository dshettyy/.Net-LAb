using StudentManagementAPI.Models;
using System.Collections.Generic;

namespace StudentManagementAPI.Services
{
    public interface IStudentService
    {
        Student Add(Student student);

        bool Delete(int usn);
        List<Student> GetAll();
        Student? GetById(int usn);
        bool Update(int usn, Student updatedStudent);
    }
}
