using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementServiceLayer
{
    public interface IStudentMarksService
    {
        Task<IList<StudentMarks>> GetStudentMarksList();

        void AddStudentMarks(StudentMarks stuMarks);

        StudentMarks SearchStudentMarks(int sem);

        bool UpdateStudent(StudentMarks stuMarks);

        ResponseModel DeleteStudentMarks(int stuId);
    }
}
