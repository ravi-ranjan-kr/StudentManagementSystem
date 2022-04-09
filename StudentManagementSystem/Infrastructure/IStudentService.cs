using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Infrastructure
{
    public interface IStudentService
    {
        Task<IList<Student>> GetStudentList();

        Student SearchStudent(int stuId);

        public void AddStudent(Student stu);

        ResponseModel DeleteStudent(int stuId);

        public bool EditStudent(Student stu);
    }
}
